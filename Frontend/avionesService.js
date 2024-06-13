const urlApi = "http://localhost:5145/aviones/GetAll"

function listarAviones(){
    fetch(urlApi) //llamado a API GET por defecto
    .then((respuesta) => respuesta.json()) //convierte el string de respuesta en un json
    .then((respuesta) => {
        if(!respuesta.success){
            let error = "Error al consumir la API: " + respuesta.errorMessage
            alert(error)
        }
        else{
            const cuerpoTabla = document.querySelector('tbody') //guardo el cuerpo de la tabla que deje en blanco

            respuesta.data.forEach(avion => {
                const filaTabla = document.createElement('tr') //creo una fila e la tabla
                //voy agregando las columnas
                filaTabla.innerHTML += "<td>" + avion.matricula + "</td>"
                filaTabla.innerHTML += "<td>" + avion.cantidadPasajesros + "</td>"
                filaTabla.innerHTML += "<td>" + avion.marca + "</td>"

                cuerpoTabla.append(filaTabla) //agrego la fila a la tabla
            });
        }
    }).catch(err => {
        alert("algo malio sal... " + err)
    })
}