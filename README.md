# net_tdd_beginner
Este repo es una implementacion de TDD sobre un proyecto simple, esta orientado a los DEVs que estan iniciando en esta practica y necesitan algo con que jugar.

Si este proyecto te sirve para completar alguna capacitacion que estes dando, sentite libre de clonarlo y utilizarlo. Tambien podes enviarme sugerencias de mejoras siempre y cuando sea para principiantes.

Mas informacion en el [blog de andreani](https://medium.com/code4ndreani) 
<br/>

## Casos de uso.
 - Crear un alumno
 - Ver un lumno
 - Ver todos los alumnos
 - Ingresar nota a un alumno
 - Verificar el historial de notas y el estado del alumno segun el promedio.
<br/>

## Condiciones de los estados de los alumnos segun  nota.

Las calificaciones se miden desde el 0 al 10 y el estado del alumno se calcula por el promedio:
 - Entre 0 y 4 es desaprobado.
 - Entre 5 y 6 es insuficiente.
 - Entre 7 y 10 es aprobado.
<br/>

## Variables de entorno ( .env )

| Nombre                 | Descripcion                 | Default |
|:-----------------------|:---------------------------:|--------:|
| MONGO-CONNECTIONSTRING | Connection string de MongoDB| -       |
| MONGO-DATABASE         | Nombre de la base de datos  | -       |