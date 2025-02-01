# 🧪 Integration Tests

Acest director conține **testele de integrare**. Scopul este să verificăm dacă modulele și serviciile aplicației funcționează corect împreună.

## 🚀 Cum rulezi testele?

1. **Linie de comandă**:
   Rulează comanda:
   ```bash
   dotnet test

2. **Din IDE**:
  Dechide VS Code sau Visual Studio și folosește Test Explorer pentru a rula testele 


# 📈 Performance Tests 

Acest director include testele de performanță pentru evaluarea aplicației sub diverse niveluri de încărcare.

## 🚀 Cum rulezi testele?

1. Execută un script de testare:
   ```bash
   k6 run load_test.js


## 📊 Tipuri de teste
- Load Testing: Simulează încărcare moderată.
- Stress Testing: Crește numărul de utilizatori până la limita maximă.
- Spike Testing: Simulează creșteri bruște de trafic.
- Soak Testing: Menține o încărcare constantă pentru o perioadă îndelungată (ex. câteva ore) pentru a verifica probleme de memorie, stabilitate sau scurgeri de resurse (memory leaks).



## 💻 Interpretarea rezultatelor
Terminal Output:
k6 va afișa metrice de tip requests/sec, timpi de răspuns (p95, p99), rate de eroare (HTTP status code > 399), etc.
