# Lab 3 - EGC  
**Autor:** Zagan Cristian  
**Grupa:** 3133A  

---

### Puncte cheie

1. **Ordinea vertexurilor**  
   Vertexurile trebuie definite în sens **anti-orar**.

2. **Anti-aliasing**  
   Anti-aliasing este o modalitate prin care se netezesc marginile și culorile dintr-o imagine sau un font, oferind un aspect cât mai natural.

3. **Line Width și Point Size**  
   - `LineWidth` specifică lățimea liniei în funcție de valoarea parametrului dat.
   - `PointSize` reprezintă diametrul unui punct în funcție de valoarea parametrului dat.  
   > Notă: Dacă `LineWidth` sau `PointSize` sunt setate în interiorul unui bloc `GL.Begin()`, acestea nu se aplică, deși nu se generează eroare. Dimensiunea va fi cea implicită.

4. **Tipuri de primitive în OpenGL**  
   - `GL.Begin(PrimitiveTypes.LineLoop)`: Specifică un poligon cu vârfurile unite în ordinea dată, formând o buclă.
   - `GL.Begin(PrimitiveTypes.LineStrip)`: Specifică o polilinie de la vârful inițial până la ultimul, conectând vârfurile în ordinea dată.
   - `GL.Begin(PrimitiveTypes.TriangleFan)`: Conectează mai multe triunghiuri, având un vârf comun.
   - `GL.Begin(PrimitiveTypes.TriangleStrip)`: Unește mai multe triunghiuri, dar acestea nu au același vârf.

5. **Utilizarea culorilor în obiectele 3D**  
   Aplicarea unor culori diferite pe fețele obiectelor 3D evidențiază fiecare față distinct, facilitând diferențierea liniilor și punctelor.

6. **Gradient de culoare**  
   Un **gradient de culoare** specifică o gamă de culori dependente de poziție, utilizate de obicei pentru a umple o regiune. Se realizează prin asignarea unei culori fiecărei forme.

7. **Setarea culorii transparente**  
   Setând `Color.Transparent` pe un vertex, acesta va apărea **alb**.

8. **Gradient în obiecte 3D**  
   Când fiecare vertex are o altă culoare, obiectul 3D va fi redat cu un **efect de gradient**.

---
