# net_tdd_beginner
Este repo es una implementacion de una aplicacion ejemplo para una capacitacion sobre TDD que debo preparar. Esta desarrollada para poder pararse en cualquier commit y eliminar el codigo implementado para ir cumpliendo con las expectativas de los test.

<br/>
# Casos de uso.
 - Crear un alumno
 - Ver un lumno
 - Ver todos los alumnos
 - Ingresar nota a un alumno
 - Verificar el historial de notas y el estado del alumno segun el promedio.
 
<br/>
# Condiciones de los estados de los alumnos segun  nota.
Las calificaciones se miden desde el 0 al 10 y el estado del alumno se calcula por el promedio:
 - Entre 0 y 4 es desaprobado.
 - Entre 5 y 6 es insuficiente.
 - Entre 7 y 10 es aprobado.
 
 
<br/>
# Variables de entorno ( .env )
| Nombre                 | Descripcion                 | Default |
|:-----------------------|:---------------------------:|--------:|
| MONGO-CONNECTIONSTRING | Connection string de MongoDB| -       |
| MONGO-DATABASE         | Nombre de la base de datos  | -       |