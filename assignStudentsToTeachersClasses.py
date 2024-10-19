from itertools import combinations


def suprapunere_intervale(interval1, interval2):
    def parse_interval(interval):
        if isinstance(interval, tuple):
            start, end = interval
        elif "-" in interval:
            start, end = interval.split("-")
        else:
            start = interval
            end = interval
        return int(start.replace(":", "")), int(end.replace(":", ""))

    try:
        start1, end1 = parse_interval(interval1)
        start2, end2 = parse_interval(interval2)
        return max(start1, start2) < min(end1, end2)
    except ValueError:
        print(f"Formatul de interval este invalid: interval1={interval1}, interval2={interval2}")
        return False

reader = open("input.txt", "r")

line = reader.readline()
profesor_disponibilitate = {}
while line != "\n" and line != "": 
    input = line.strip().split(":", 1)
    if "-" not in input[1].strip():
        line = reader.readline()
        continue
    profesor_disponibilitate[input[0].strip()] = [tuple(map(str.strip, hours.strip().split("-"))) for hours in input[1].split(",")]
    
    line = reader.readline()


elevi = []
while line != "":
    line = reader.readline()
    if line == "":
        break
    
    toAppend = {}
    input = line.strip().split("-")
    toAppend["nume"] = input[0].strip()
    toAppend["dificultate"] = int(input[1].strip())
    toAppend["disponibilitate"] = {}
    
    line = reader.readline()
    while line != "\n" and line != "": 
        input = line.strip().split(":", 1)
        if "-" not in input[1].strip():
            line = reader.readline()
            continue
        toAppend["disponibilitate"][input[0].strip()] = [tuple(map(str.strip, hours.strip().split("-"))) for hours in input[1].split(",")]
    
        line = reader.readline()
        
    elevi.append(toAppend)


# elevi = [
#     {"nume": "Alex Radulescu", "dificultate": 8, "disponibilitate": {
#                                         "Mo": [("10:00", "14:00"), ("18:00", "20:00")],
#                                         "We": [("13:00", "15:00")],
#                                         "Fr": [("14:00", "16:00")],
#                                         "Sa": [("16:00", "18:00")],
#                                         "Su": [("10:00", "12:00")]}},
#     {"nume": "Mihai Ionescu", "dificultate": 7, "disponibilitate": {
#                                         "Mo": [("12:00", "16:00")],
#                                         "Tu": [("11:00", "13:00")],
#                                         "Fr": [("14:00", "16:00")],
#                                         "Su": [("10:00", "12:00")]}},
#     {"nume": "Radu Constantin", "dificultate": 9, "disponibilitate": {
#                                         "We": [("10:00", "12:00")]}},
#     {"nume": "Iacob Deleanu", "dificultate": 6, "disponibilitate": {
#                                         "Mo": [("10:00", "12:00")],
#                                         "Tu": [("14:00", "16:00")],
#                                         "We": [("10:00", "12:00"), ("18:00", "20:00")],
#                                         "Fr": [("15:00", "17:00")]}}
# ]


# profesor_disponibilitate = {
#     "Mo": [("08:00", "10:00"), ("14:00", "20:00")],
#     "Tu": [("12:00", "18:00")],
#     "We": [("10:00", "14:00"), ("16:00", "18:00")],
#     "Th": [("10:00", "18:00")],
#     "Fr": [("13:00", "17:00")],
#     "Sa": [("14:00", "16:00")],
#     "Su": [("10:00", "12:00"), ("13:00", "15:00")]
# }


n = 4
m = 2


def verifica_grupa(grupa, m):
    dificultati = [e['dificultate'] for e in grupa]
    return max(dificultati) - min(dificultati) <= m


def backtracking_solutie(elevi, n, m, profesor_disponibilitate):
    max_elevi_alocati = 0
    solutie_optimala = []
    elevi_nealocati = elevi.copy()


    def backtrack(elevi_ramas, grupe_curente, elevi_alocati):
        nonlocal max_elevi_alocati, solutie_optimala, elevi_nealocati


        if elevi_alocati > max_elevi_alocati:
            max_elevi_alocati = elevi_alocati
            solutie_optimala = grupe_curente[:]
            elevi_nealocati = elevi_ramas[:]


        for zi, intervale_prof in profesor_disponibilitate.items():
            for interval_prof in intervale_prof:

                for grupa_dim in range(1, n + 1):
                    for grupa in combinations(elevi_ramas, grupa_dim):

                        if verifica_grupa(grupa, m):
                            if all(any(suprapunere_intervale(interval_prof, elev_interval)
                            for elev_interval in elev['disponibilitate'].get(zi, [])) for elev in grupa):


                                elevi_ramas_nou = [elev for elev in elevi_ramas if elev not in grupa]
                                backtrack(elevi_ramas_nou, grupe_curente + [(zi, interval_prof, grupa)], elevi_alocati + len(grupa))


    backtrack(elevi, [], 0)

    return solutie_optimala, elevi_nealocati



solutie, elevi_nealocati = backtracking_solutie(elevi, n, m, profesor_disponibilitate)


print("Grupe formate (solutie optima cu backtracking):")
for zi, interval, grupa in solutie:
    print(f"Ziua {zi}, intervalul {interval}: {[elev['nume'] for elev in grupa]}")

print("\nElevi nealocati:")
for elev in elevi_nealocati:
    print(elev['nume'])
