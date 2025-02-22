﻿# **SOFTWARE-ENGINEERING-PRODUCT-TOPTEAM**

# **INVATAMONLINEDE10: PLATFORMA DE MEDITAȚII CARE OFERĂ O MODALITATE UNICĂ DE ÎNVĂȚARE ȘI PREDARE**


# Product Vision

**CINE:** Pentru cei care au nevoie de ajutor sa înțeleagă mai bine materia sau vor să se pregătească pentru examene importante

**InvatamOnlineDe10 ESTE:** O platformă de meditații online, prin care elevii din toată țara se conectează cu profesorii în vederea înțelegerii materiei școlare atât în ansamblu, cât și detaliat

**SPRE DEOSEBIRE DE:** Platformele de cursuri, "InvatamOnlineDe10" asistă într-un mod intuitiv ședințele de apel video și pune la bătaie o platformă prin care atât elevii, cât și profesorii pot comunica, vizualiza/ încărca teme și reviziona ședințele de meditații.

**PLATFORMA NOASTRĂ:** Oferă o experientă unică elevilor care se pregătesc pentru examene sau au probleme în a înțelege materia. Creează o comunitate de elevi care au același scop și centralizează toate datele de care aceștia au nevoie pentru a ajunge la scopul propus. Totodată "InvatamOnlineDe10" oferă elevilor, dar și părinților statistici legate de procesul lor de învățare, astfel încât, elevul să nu rămână cu probleme, iar profesorul să știe unde este problema care trebuie rezolvată.

---
# Product Features
- **Roluri**
  - Profesor, Elev, Administrator

- **Logare/Înregistrare**
  - Confirmare email pentru user și administrator (necesar un telefon înainte de înregistrare).
- **Plăți și Abonamente**
  - Situație plată / câți bani ai de plătit.
  - Vizualizare abonamente.
  - Blocare conținut de către administrator pentru un anumit curs (în cazul neplății, dar păstrarea temelor/cursurilor postate anterior); după plata, afișarea postărilor noi.
- **Vizualizare Materiale**
  - Vizualizare teme/cursuri/lecții încărcate de profesor.
- **Chat și Comunicare**
  - Chat elev-profesor pentru grupă/semigrupă.
  - Grupă/semigrupă (20 grup elevi, 5 semigrupă).
- **Sesiuni Online**
  - Încărcare link Google Meet pentru grupă/semigrupă.
- **Repartizare Automată**
  - Repartizare automată în funcție de ore disponibile și nivel de studenți.
- **Încărcare și Evaluare Teme**
  - Încărcare teme elevi.
  - Notare elevi tema.
  - Note elevi în funcție de nota de la tema.
- **Dashboard și Statistici**
  - Dashboard profesori în funcție de notele elevilor; statistica pentru înțelegerea nivelului după un anumit capitol.
  - Dashboard prezență curs.
- **Setări Cont**
  - Setări administrative (schimbare parolă, email, nr telefon).
- **Schimbare Curs**
  - Schimbare cursuri.
- **Profil Profesor**
  - Încărcare video-uri de către profesor pe platformă.
  - Poză de profil (alegere din mai multe caractere).
- **Feedback**
  - Feedback după fiecare curs anonim.
- **Calendar**
  - Calendar integrat.
- **Support Platformă**
  - Support pentru probleme tehnice și funcționale.
- **Conexiune Securizată**
  - Conexiune SSL/TLS și reînnoirea conexiunii SSL/TLS
  - Redirecționarea traficului HTTP către HTTPS
- **Gestionarea traficului intens**
  - Echilibrarea încărcării între servere multiple
  - Scalare automată oferită de load balancer

---
# User Stories

**User Story 1: Logare/Inregistrare și Confirmare Email**

Ca un utilizator,vreau să mă pot înregistra cu un email valid și să primesc un cod
de confirmare pe email, astfel încât să îmi pot activa contul. Ca un administrator,
vreau să confirm conturile noi printr-un telefon pentru verificare, astfel încât să am
siguranța că toți utilizatorii sunt reali.  
**Backlog:**
1. Formular de înregistrare cu validare email.
2. Trimiterea codului de confirmare prin email.
3. Verificare email și activare cont.
4. Verificare telefonică pentru administratori.
---


**User Story 2: Vizualizare Cursuri și Teme**

Ca un elev, vreau să pot vizualiza cursurile și temele încărcate de profesor, astfel încât să pot accesa materialele necesare pentru învățare. Ca un profesor, vreau să încarc teme și lecții pentru grupurile mele de elevi, astfel încât să pot distribui materialele educaționale.  
**Backlog:**
1. Listarea cursurilor pentru elevi.
2. Încărcarea temelor și cursurilor de către profesori.
3. Vizualizarea lecțiilor și temelor încărcate.

---

**User Story 3: Încărcare Video și Linkuri Google Meet**

Ca un profesor, vreau să pot încărca video-uri pe platformă și să creez linkuri pentru sesiuni Google Meet, astfel încât să îmi pot desfășura cursurile online.  
**Backlog:**
1. Opțiunea de încărcare video.
2. Integrare Google Meet pentru sesiuni live.

---

**User Story 4: Vizualizare și Administrare Abonamente**

Ca un elev, vreau să îmi pot vizualiza situația plății și abonamentul, astfel încât să știu dacă am plătit și cât am de plată. Ca un administrator, vreau să pot bloca accesul la anumite cursuri pentru elevii care nu au plătit, dar să păstrez accesul la lecțiile anterioare, astfel încât să gestionez eficient abonamentele.  
**Backlog:**
1. Sistem de vizualizare și gestionare a abonamentelor pentru elevi și administratori.
2. Blocarea accesului la cursuri neplătite.

---

**User Story 5: Chat Elev-Profesor**

Ca un elev, vreau să pot comunica cu profesorul și colegii mei printr-un chat de grup, astfel încât să pot adresa întrebări și discuta subiecte de curs. Ca un profesor, vreau să pot răspunde elevilor din grupa mea pentru a le oferi feedback în timp real.  
**Backlog:**
1. Sistem de chat integrat în platformă.
2. Opțiune de grup pentru elevi și profesori.
3. Notificări pentru mesaje noi.

---

**User Story 6: Încărcare Teme de Elevi și Notare**

Ca un elev, vreau să pot încărca temele mele pe platformă, astfel încât profesorul să le poată evalua. Ca un profesor, vreau să pot evalua și nota temele încărcate de elevi, astfel încât să le ofer un feedback clar și să le urmăresc progresul.  
**Backlog:**
1. Formular de încărcare teme pentru elevi.
2. Secțiune de evaluare și notare pentru profesori.

---

**User Story 7: Dashboard pentru Elevi și Profesori**

Ca un elev, vreau să văd un dashboard cu toate temele mele, notele primite și progresul la cursuri, astfel încât să îmi urmăresc performanța. Ca un profesor, vreau să am un dashboard cu statistici despre notele și progresul elevilor la diferite capitole, astfel încât să pot evalua nivelul general al grupei mele.  
**Backlog:**
1. Dashboard cu informații despre teme, note și progres.
2. Statistici generale pentru profesori.

---

**User Story 8: Calendar și Notificări**

Ca un elev, vreau să am acces la un calendar integrat cu orele cursurilor și termenele limită pentru teme, astfel încât să îmi pot planifica timpul. Ca un profesor, vreau să pot trimite notificări către elevi pentru a le reaminti de cursuri sau teme.  
**Backlog:**
1. Calendar integrat pentru cursuri și termene.
2. Sistem de notificări pentru teme și cursuri.

---

**User Story 9: Repartizare Automată a Elevilor**

Ca un administrator, vreau să repartizez automat elevii în grupe și semigrupuri, bazat pe nivelul lor și disponibilitatea orară, astfel încât să optimizez distribuția.  
**Backlog:**
1. Algoritm de repartizare automată bazat pe disponibilitate și nivel.
2. Posibilitate de ajustare manuală de către administratori.

---

**User Story 10: Feedback și Anonimat**

Ca un elev, vreau să ofer feedback anonim după fiecare curs, astfel încât să îmi exprim opinia fără să îmi fie cunoscută identitatea.  
**Backlog:**
1. Formular de feedback anonim.
2. Procesarea feedback-ului fără a afișa identitatea.

---

**User Story 11: Modificare Date Cont**

Ca un elev, vreau să îmi pot modifica datele contului (parolă, email, număr de telefon), astfel încât să îmi pot actualiza informațiile personale.  
**Backlog:**
1. Formular de modificare date cont.
2. Actualizarea bazei de date cu noile informații.

---

**User Story 12: Raportare Probleme pe Platformă**

Ca un elev, vreau să pot raporta probleme tehnice sau legate de conținut pe platformă, astfel încât să pot primi ajutor în rezolvarea acestora.  
**Backlog:**
1. Sistem de raportare a problemelor.
2. Notificare către echipa de suport.

---

**User Story 13: Abonare la Alte Cursuri**

Ca un elev, vreau să mă pot abona la alte cursuri disponibile pe platformă, astfel încât să îmi extind cunoștințele și să accesez mai multe materiale.  
**Backlog:**
1. Adăugare secțiune "Cursuri Disponibile" în dashboard-ul elevilor.
2. Implementare funcționalitate de abonare, incluzând verificarea stării de plată și stocarea abonamentelor în baza de date.
3. Generare de facturi și notificări de confirmare a abonamentului.
4. Actualizare sistem de acces la cursuri, în funcție de abonamentele active.

---

**User Story 14: Predare la Mai Multe Grupe**

Ca un profesor, vreau să am posibilitatea de a preda la mai multe grupe simultan, astfel încât să îmi pot gestiona eficient timpul și elevii.  
**Backlog:**
1. Modificare profilului profesorilor pentru a permite gestionarea mai multor grupe.
2. Creare unei interfețe de administrare a grupelor pentru fiecare profesor.
3. Sistem de programare a lecțiilor, sincronizat cu grupele la care predă.
4. Vizualizare centralizată a elevilor și temelor din toate grupele.

---






**User Story 15: Anulare Abonament de către Profesor**

Ca un profesor, vreau să am opțiunea de a anula un abonament la un curs, astfel
încât să pot renunța la predarea unui curs dacă este necesar.  
**Backlog:**
1. Opțiune pentru anularea abonamentului la cursuri.
2. Notificare către elevi despre anularea cursului.
---


**User Story 16: Acces online securizat**

Ca utilizator, vreau ca accesul meu la platformă să fie securizat, astfel încât să am încredere că datele mele sunt protejate pe durata transmiterii.  
**Backlog:**
1. Activarea terminației SSL/TLS la nivelul load balancer-ului pentru a decripta traficul HTTPS de intrare. 
2. Configurarea și gestionarea certificatelor SSL/TLS și a procesului de reînnoire automată. 
3. Redirecționarea întregului trafic HTTP către HTTPS pentru a asigura conexiuni securizate. 
---


**User Story 17: Gestionarea eficientă a traficului intens**

Ca utilizator, vreau ca platforma să gestioneze eficient multiple cereri, astfel încât să pot accesa fără întârzieri, chiar și în perioade de trafic intens.  
**Backlog:**
1. Configurarea echilibrării încărcării între servere multiple pentru a distribui traficul de intrare. 
2. Implementarea persistenței sesiunilor (sticky sessions) pentru a asigura continuitatea sesiunilor utilizatorilor când este necesar. 
3. Configurarea verificărilor de sănătate pentru monitorizarea disponibilității serverelor și redirecționarea traficului departe de serverele indisponibile. 
4. Stabilirea scalării automate pentru load balancer pentru a face față fluctuațiilor de trafic. 


---
# Descriere Model de Bază de Date

Modelul bazei de date este structurat pentru a gestiona activitatea platformei. Utilizatorii se pot înregistra atât ca elevi, cât și ca profesori, iar profesorii pot crea și administra cursuri, adăugând materiale și teme pentru elevi.

Elevii sunt organizați în grupe și pot accesa cursurile la care sunt înscriși. Fiecare curs are asociate sesiuni de predare (ședințe) planificate, care pot fi evaluate ulterior prin feedback. Profesorii și elevii pot comunica între ei prin mesaje private sau de grup, iar sistemul include un mecanism de notificări pentru a ține utilizatorii informați despre activitățile curente.

Plățile pentru cursuri sunt evidențiate printr-un sistem gestionat, iar după finalizarea cursurilor, elevii pot lăsa recenzii asupra experienței lor de învățare.

---

## Diagrama E/R

![](Documentatie/DiagramaER.jpeg)

---

## Diagrama Conceptuală

![](Documentatie/DiagramaConceptuala.jpeg)

---

## Descrierea Entităților

- **TEMĂ** – Reprezintă o lucrare atribuită utilizatorilor de către un profesor, care poate fi accesată prin intermediul unui fișier.
- **PROFESOR** – Persoană responsabilă cu administrarea temelor, grupelor și ședințelor.
- **ELEV** – Reprezintă un utilizator elev, identificat printr-un ID unic, cu date personale și de autentificare.
- **MESAJ** – Permite trimiterea de mesaje către un utilizator sau un grup.
- **RĂSPUNS TEMA** – Răspunsul unui utilizator la o temă, ce poate include un fișier și un punctaj primit.
- **SUPORT** – Mesaj trimis de un utilizator pentru a primi asistență în cadrul platformei.
- **GRUPĂ** – Un grup de utilizatori care urmează un curs și participă la ședințe organizate de un profesor.
- **USER** – Model de autentificare comun pentru utilizatorii sistemului (elevi și profesori), integrat în entitățile "Elev" și "Profesor".
- **CURS** – Reprezintă un curs educațional oferit de un profesor și accesibil unei grupe.
- **PLATĂ** – Informații despre tranzacțiile financiare efectuate pentru accesul la cursuri.
- **ȘEDINȚA** – O sesiune specifică din cadrul unui curs, unde se desfășoară activități educaționale.
- **NOTIFICARE** – Mesaj trimis către utilizatori pentru a le aduce la cunoștință informații importante.
- **FEEDBACK** – Comentarii și evaluări date de un utilizator în urma unei ședințe.
- **MATERIAL** – Reprezintă un material educațional (document, prezentare, articol, fișier, etc.) creat de un profesor pentru a susține activitatea didactică.
- **DISPONIBILITATE** – Indică intervalele orare în care un utilizator este disponibil, specificând ziua și ora de început.

---

## Descrierea Relațiilor

- **Elev participă la Curs** – Relație care leagă entitățile Elev și Curs, cardinalitate M:M.
- **Curs este urmat de o Grupa** – Relație între Curs și Grupa, cardinalitate M:1.
- **Curs generează Plata** – Relație între Curs și Plata, cardinalitate 1:M.
- **Curs predat de Profesor** – Relație între Curs și Profesor, cardinalitate M:M.
- **User trimite solicitari Suport** – Relație între User și Suport, cardinalitate 1:M.
- **Elev trimite răspuns Tema** – Relație între Elev și Raspuns_Tema, cardinalitate 1:M.
- **User trimite Mesaj** – Relație între User și Mesaj, cardinalitate 1:M.
- **User face parte din Grupa** – Relație între User și Grupa, cardinalitate M:M.
- **User primește Notificări** – Relație între User și Notificare, cardinalitate 1:M.
- **User participă la Sedinta** – Relație între User și Ședința, cardinalitate M:M.
- **Elev efectuează Plata** – Relație între Elev și Plata, cardinalitate 1:M.
- **Elev oferă Feedback** – Relație între Elev și Feedback, cardinalitate 1:1.
- **Grupa participă la Sedinta** – Relație între Grupa și Sedinta, cardinalitate 1:M.
- **Grupa primește Notificari** – Relație între Grupa și Notificare, cardinalitate 1:M.
- **Profesor are Disponibilitate** – Relație între Profesor și Disponibilitate, cardinalitate 1:M.
- **Grupa este invățată de Profesor** – Relație între Grupa și Profesor, cardinalitate M:1.
- **Profesor creează Teme** – Relație între Profesor și Tema, cardinalitate 1:M.
- **Profesor trimite Notificari** – Relație între Profesor și Notificare, cardinalitate 1:M.
- **Profesor creează Materiale** – Relație între Profesor și Material, cardinalitate 1:M.
- **Sedinta primește Feedback** – Relație între Sedinta și Feedback, cardinalitate 1:M.
- **Tema are un Raspuns** – Relație între Tema și Raspuns_Tema, cardinalitate 1:1.

---

## Descrierea Atributelor

### TEMA
- **TemaId**: număr natural ce reprezintă codul de identificare al temei.
- **Titlu**: variabilă de tip caracter ce reprezintă titlul temei.
- **Descriere**: variabilă de tip caracter ce reprezintă descrierea temei.
- **Fișier**: variabilă de tip caracter ce reprezintă tema.
- **ProfesorId**: număr natural ce reprezintă codul de identificare al profesorului responsabil.

### MESAJ
- **MesajId**: număr natural ce reprezintă codul de identificare al mesajului.
- **Mesaj**: variabilă de tip caracter ce reprezintă conținutul mesajului.
- **TipMesaj**: variabilă de tip caracter ce reprezintă tipul mesajului (privat, grup).
- **EmitatorId**: număr natural ce reprezintă codul de identificare al emițătorului.
- **ReceptorId**: număr natural ce reprezintă codul de identificare al receptorului (grup, elev, profesor).

### RASPUNS_TEMA
- **RaspunsTemaId**: număr natural ce reprezintă codul de identificare al răspunsului temei.
- **Fișier**: variabilă de tip caracter ce reprezintă fișierul răspunsului.
- **Punctaj**: număr natural ce reprezintă punctajul acordat.
- **TemaId**: număr natural ce reprezintă codul de identificare al temei.

### SUPORT
- **SuportId**: număr natural ce reprezintă codul de identificare al sesiunii de suport.
- **Mesaj**: variabilă de tip caracter ce reprezintă mesajul de suport.
- **UserId**: număr natural ce reprezintă codul de identificare al utilizatorului.

### MATERIAL
- **MaterialId**: număr natural ce reprezintă codul de identificare al materialului.
- **Titlu**: variabilă de tip caracter ce reprezintă titlul materialului.
- **Descriere**: variabilă de tip caracter ce reprezintă descrierea materialului.
- **Fisier**: variabilă de tip caracter ce reprezintă fișierul asociat materialului.
- **ProfesorId**: număr natural ce reprezintă codul de identificare al profesorului.

### PROFESOR
- **ProfesorId**: număr natural ce reprezintă codul de identificare al profesorului.
- **Nume**: variabilă de tip caracter ce reprezintă numele profesorului.
- **Prenume**: variabilă de tip caracter ce reprezintă prenumele profesorului.
- **Telefon**: variabilă de tip caracter ce reprezintă numărul de telefon al profesorului.
- **Email**: variabilă de tip caracter ce reprezintă adresa de email a profesorului.
- **Username**: variabilă de tip caracter ce reprezintă numele de utilizator al profesorului.
- **Parola**: variabilă de tip caracter ce reprezintă parola profesorului.
- **PozaProfil**: variabilă de tip caracter ce reprezintă calea către poza de profil a profesorului.

### GRUPA
- **GrupaId**: număr natural ce reprezintă codul de identificare al grupei.
- **Nume**: variabilă de tip caracter ce reprezintă numele grupei.
- **NivelStudii**: variabilă de tip caracter ce reprezintă nivelul de studii al grupei.
- **LinkMeet**: variabilă de tip caracter ce reprezintă link-ul pentru întâlnirile online.
- **ProfesorId**: număr natural ce reprezintă codul de identificare al profesorului asociat grupei.
- **CursId**: număr natural ce reprezintă codul de identificare al cursului.

### USER
- **Username**: variabilă de tip caracter ce reprezintă numele de utilizator pentru autentificare.
- **Parola**: variabilă de tip caracter ce reprezintă parola utilizatorului pentru autentificare.

### ELEV
- **UserId**: număr natural ce reprezintă codul de identificare al utilizatorului.
- **Nume**: variabilă de tip caracter ce reprezintă numele utilizatorului.
- **Prenume**: variabilă de tip caracter ce reprezintă prenumele utilizatorului.
- **Telefon**: variabilă de tip caracter ce reprezintă numărul de telefon al utilizatorului.
- **Email**: variabilă de tip caracter ce reprezintă adresa de email a utilizatorului.
- **Clasa**: variabilă de tip caracter ce reprezintă clasa utilizatorului.
- **Username**: variabilă de tip caracter ce reprezintă numele de utilizator.
- **Parola**: variabilă de tip caracter ce reprezintă parola utilizatorului.
- **PozaProfil**: variabilă de tip caracter ce reprezintă URL-ul imaginii utilizatorului.

### CURS
- **CursId**: număr natural ce reprezintă codul de identificare al cursului.
- **Denumire**: variabilă de tip caracter ce reprezintă denumirea cursului.
- **Descriere**: variabilă de tip caracter ce reprezintă descrierea cursului.
- **NrSedinte**: număr natural ce reprezintă numărul de ședințe ale cursului.
- **Pret**: număr natural ce reprezintă prețul cursului.

### NOTIFICARE
- **NotificareId**: număr natural ce reprezintă codul de identificare al notificării.
- **Titlu**: variabilă de tip caracter ce reprezintă titlul notificării.
- **Mesaj**: variabilă de tip caracter ce reprezintă mesajul notificării.
- **Data**: variabilă de tip dată ce reprezintă data notificării.
- **TipNotificare**: variabilă de tip caracter ce reprezintă tipul notificării (individual, grup).
- **ReceptorId**: număr natural ce reprezintă codul de identificare al receptorului (grup, profesor, elev).

### ȘEDINȚA
- **SedintaId**: număr natural ce reprezintă codul de identificare al ședinței.
- **Titlu**: variabilă de tip caracter ce reprezintă titlul ședinței.
- **Zi**: variabilă de tip dată ce reprezintă ziua în care are loc ședința.
- **OraIncepere**: variabilă de tip dată ce reprezintă ora de începere a ședinței.
- **OraIncheiere**: variabilă de tip dată ce reprezintă ora de încheiere a ședinței.
- **GrupaId**: număr natural ce reprezintă codul de identificare al grupei participante la ședință.

### DISPONIBILITATE
- **DisponibilitateId**: număr natural ce reprezintă codul de identificare al disponibilității.
- **Zi**: variabilă de tip caracter ce reprezintă ziua săptămânii.
- **OraIncepere**: variabilă de tip oră ce reprezintă ora de începere a disponibilității.
- **UserId**: număr natural ce reprezintă codul de identificare al utilizatorului disponibil.

### PLATA
- **PlataId**: număr natural ce reprezintă codul de identificare al plății.
- **Suma**: număr natural ce reprezintă suma plătită.
- **Data**: variabilă de tip dată ce reprezintă data plății.
- **UserId**: număr natural ce reprezintă codul de identificare al utilizatorului.
- **CursId**: număr natural ce reprezintă codul de identificare al cursului plătit.

### FEEDBACK
- **FeedbackId**: număr natural ce reprezintă codul de identificare al feedback-ului.
- **Mesaj**: variabilă de tip caracter ce reprezintă conținutul feedback-ului.
- **SedintaId**: număr natural ce reprezintă codul de identificare al ședinței.
- **UserId**: număr natural ce reprezintă codul de identificare al utilizatorului ce a oferit feedback.





---
# Diagrama UML
În cadrul proiectelor care pun accent pe munca în echipă, o reprezentare grafică pentru a vizualiza elementele platformei și modul în care acestea relaționează sporește productivitatea echipei, făcând fiecare funcționalitate a platformei să fie concisă la implementare.

Pentru platforma “InvatamOnlineDe10” a fost realizată următoarea diagramă care ilustrează stările platformei, acțiunile pe care utilizatorul le poate face, precum și stările în care aceste acțiuni pot fi făcute.

![](Documentatie/DiagramaUML.jpg)
Diagrama UML de activitate ne oferă o imagine de ansamblu asupra fluxurilor pe care le urmează utilizatorii. O scurtă prezentare a acestora:

## 1. Accesul la Platformă
- Utilizatorul intră pe platformă și este întâmpinat de un dialog care îl întreabă dacă are deja cont.
  - **Dacă are un cont**: Utilizatorul este redirecționat către autentificare, unde, după introducerea credențialelor, va fi dus pe pagina principală.
  - **Dacă nu are un cont**: Utilizatorul este redirecționat către procesul de înregistrare, unde completează detaliile contului.

## 2. Confirmarea Contului
- În cazul înregistrării, contul utilizatorului trebuie confirmat.
  - **Dacă contul este confirmat**: Utilizatorul poate accesa platforma.
  - **Dacă contul nu este confirmat**: Utilizatorul nu poate folosi platforma.

## 3. Pagina Principală (Main Page)
- După autentificare, utilizatorul ajunge pe pagina principală, unde are acces la diverse funcționalități:
  - **Magazin de Cursuri**: Utilizatorul poate căuta, filtra și vizualiza cursurile disponibile.
  - **Notificări**: Utilizatorul poate vizualiza notificările primite.
  - **Support**: Utilizatorul poate trimite solicitări de suport dacă întâmpină probleme.

## 4. Setările Contului (Setari)
- În secțiunea de setări, utilizatorul poate accesa:
  - **Profilul**: unde își poate vedea și modifica datele personale.
  - **Situația Plății**: unde poate vedea detalii despre abonamentele și plățile efectuate.
  - **Abonamente**:
    - **Listă Abonamente și Prețuri**: Utilizatorul poate vizualiza abonamentele disponibile și prețurile acestora.
    - **Abonamente Actuale**: Utilizatorul poate vizualiza abonamentele active și poate anula abonamentele, dacă dorește.
    - **Detalii Modalitate de Plată**: Utilizatorul poate vedea detalii despre metodele de plată disponibile.

## 5. Interacțiunea în Cursurile Selectate
- După ce a selectat un curs, utilizatorul are acces la mai multe funcționalități:
  - **Private Chat cu Profesorul**: Utilizatorul poate comunica direct cu profesorul.
  - **Group Chat**: Utilizatorul poate comunica cu colegii săi din grupă.
  - **Selectare Ședință**: Utilizatorul poate alege o ședință la care să participe.
  - **Vizualizare Materiale**: Utilizatorul poate vizualiza materialele educaționale încărcate pentru acel curs.
  - **Buton Link pentru Meet**: Este oferit un link către Google Meet sau o platformă similară pentru ședințele live.
  - **Încărcare Temă**: Utilizatorul poate încărca teme pentru evaluare.
  - **Feedback**: Utilizatorul poate lăsa feedback despre ședințe sau despre experiența sa în cadrul cursului.

## 6. Notificări
- Utilizatorul primește notificări cu privire la activitățile relevante (de exemplu, modificări în curs, noi materiale încărcate, mementouri pentru ședințe sau teme etc.).

## 7. Redirecționare și Confirmări
- Utilizatorul este informat despre succesul sau eșecul anumitor acțiuni (cum ar fi schimbarea de date personale sau anularea unui abonament).
- După ce este luată o decizie, utilizatorul primește o confirmare de succes sau eroare, în funcție de rezultatul acțiunii.

---
# User Personas

## Pentru cine construim acest produs?

Pentru:  
**1. Elevi**  
**2. Profesori**  
**3. Studenți**  

---

### 1. Elevi

Meditațiile au ajuns un fenomen foarte răspândit printre elevi. Un număr foarte mare de elevi din generală și din liceu apelează la meditații pentru a se pregăti de examenul de Evaluare Națională, de Bacalaureat și de admitere. [Un studiu la nivel național](https://www.facebook.com/events/3993942894028746/) realizat de IRES și Societatea Academică din România, lansat anul trecut, a arătat că circa o treime (31%) dintre elevii claselor V-XII fac meditații. În anul școlar 2020-2021, [conform raportului privind starea învățământului preuniversitar din România](https://www.edu.ro/sites/default/files/_fi%C8%99iere/Minister/2021/Transparenta/Stare%20invatamant/Raport_stare_invatamant_preuniversitar_RO_2020_2021.pdf), în învățământul gimnazial erau 707.201 de elevi, iar în învățământul liceal, 616.533. Acest lucru ne indică faptul că, în total, în învățământul preuniversitar, erau 1.323.734 de elevi în anul școlar 2020-2021, din care estimativ, 31% fac meditații (410.357).

#### Declarații ale elevilor:
- **Elev1**: „Fac meditații la română, la matematică și la fizică”
- **Elev2**: „Fac meditații la biologie și la chimie”
- **Elev3**: „Eu la matematică și o să fac și la română”  

Sursă: [Știrile Antena1](https://www.tiktok.com/@observatorantena1/video/7278653495203433760)  

- **Ilinca**, elev în clasa a XII-a: „Te ajută să-ți organizezi o modalitate mult mai bună de a învăța. Îți fixează materia și noțiunile mult mai bine. De asemenea, ai o încredere crescută, ești conștient de faptul că te descurci, știi suficient de bine și ești suficient de pregătit.”  

Sursă: [Știrile Antena1](https://www.tiktok.com/@observatorantena1/video/7278653495203433760)

- **Elevă**: „Am făcut meditații în gimnaziu.”  
  - **Reporter**: „La ce materii?”
  - **Elevă**: „La română, mate și franceză”  
  - **Reporter**: „Câte persoane erați într-o grupă la meditații?”
  - **Elevă**: „La matematică făceam singură, iar la română eram 5”  

Sursă: [Știrile ProTV](https://www.youtube.com/watch?v=IOcaoTyLQsI)

Pe de altă parte, numărul de părinți care consideră necesară pregătirea suplimentară este în creștere. Potrivit [studiului](https://ires.ro/articol/430/studiu-na-ional:-fenomenul-medita%C8%9Biilor-in-romania?fbclid=IwAR1SMSAhr5is6CiPUpUSGmCGfbGVd2k1pe8QmGtNoAtSXC2CmDMP9hy7MYU), majoritatea părinților sunt de acord că elevii au nevoie de meditații pentru a dobândi cunoștințe la nivel mediu.

- **Părinte**: „Consider că e necesar să mai facă câteva ore în plus”  

Sursă: [Știrile ProTV](https://stirileprotv.ro/stiri/actualitate/parintii-cauta-centre-de-meditatii-pentru-copiii-lor-studentii-meditatori-care-cauta-un-un-venit-in-plus.html)

---

### 2. Profesori

De asemenea, numărul profesorilor care dau meditații a crescut. [Un studiu arată că numărul profesorilor care și-au declarat venituri din meditaţii a crescut cu peste 48% în 2023 faţă de 2021](https://evz.ro/cati-bani-scot-profesorii-din-meditatii-s-au-dublat-veniturile-fata-de-anul-trecut.html). Așadar, 11.734 de profesori au declarat că în 2023 au oferit meditații.

---

### 3. Studenți

În cadrul pieței meditațiilor au apărut și orele suplimentare oferite de studenți. [Aceștia oferă și ei ore suplimentare asemănător profesorilor, fiind din ce în ce mai căutați de elevii care doresc să-și îmbunătățească cunoștințele.](https://stirileprotv.ro/stiri/actualitate/parintii-cauta-centre-de-meditatii-pentru-copiii-lor-studentii-meditatori-care-cauta-un-un-venit-in-plus.html)

- **Codruța**, primul an de master la economie, oferă meditații: „E un sentiment chiar super satisfăcător, mai ales când vezi rezultatele. Mulți care m-au contactat mi-au zis că în mod deliberat căutau studenți pentru meditații”  

Sursă: [Știrile ProTV](https://stirileprotv.ro/stiri/actualitate/parintii-cauta-centre-de-meditatii-pentru-copiii-lor-studentii-meditatori-care-cauta-un-un-venit-in-plus.html)

- **Rareș**, student în ultimul an la Facultatea de Litere: „De obicei îmi pun meditațiile astfel încât să pot ajunge și la ore”  

Sursă: [Știrile ProTV](https://stirileprotv.ro/stiri/actualitate/parintii-cauta-centre-de-meditatii-pentru-copiii-lor-studentii-meditatori-care-cauta-un-un-venit-in-plus.html)
