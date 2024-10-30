from pulp import LpMaximize, LpProblem, LpVariable, lpSum
from itertools import combinations

def suprapunere_intervale(interval1, interval2):
    def parse_interval(interval):
        if isinstance(interval, tuple):
            start, end = interval
            print("Ceva111111")
        elif "-" in interval:
            start, end = interval.split("-")
        else:
            start = interval
            end = interval
            print("Ceva3333333")
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

model = LpProblem(name="maximal-student-allocation", sense=LpMaximize)

x = {}
for zi, intervale in profesor_disponibilitate.items():
    for interval_prof in intervale:
        for grupa_dim in range(1, n + 1):
            for grupa in combinations(elevi, grupa_dim):
                if all(any(suprapunere_intervale(interval_prof, elev_interval)
                        for elev_interval in elev["disponibilitate"].get(zi, [])) for elev in grupa):
                    if max(e["dificultate"] for e in grupa) - min(e["dificultate"] for e in grupa) <= m:
                        grupa_key = tuple(e["nume"] for e in grupa)
                        var_name = f"x_{zi}_{interval_prof}_{'_'.join(grupa_key)}"
                        x[(zi, interval_prof, grupa_key)] = LpVariable(var_name, cat='Binary')


model += lpSum(len(grupa_key) * x[(zi, interval_prof, grupa_key)] for (zi, interval_prof, grupa_key) in x), "Total_elevi_alocati"


for elev in elevi:
    model += lpSum(x[(zi, interval_prof, grupa_key)]
        for (zi, interval_prof, grupa_key) in x if elev["nume"] in grupa_key) <= 1, f"Restrictie_{elev['nume']}"


model.solve()


grupe_formate = []
for (zi, interval_prof, grupa_key), var in x.items():
    if var.varValue == 1:
        grupe_formate.append((zi, interval_prof, grupa_key))

print("Grupe formate (solutie optima cu programare liniara):")
for zi, interval, grupa_key in grupe_formate:
    print(f"Ziua {zi}, intervalul {interval}: {list(grupa_key)}")


elevi_alocati = {nume for (_, _, grupa_key) in grupe_formate for nume in grupa_key}
elevi_nealocati = [elev for elev in elevi if elev["nume"] not in elevi_alocati]

print("\nElevi nealocati:")
for elev in elevi_nealocati:
    print(elev["nume"])
