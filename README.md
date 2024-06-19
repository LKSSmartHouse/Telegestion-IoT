# Ejecución de la Función de Azure
Esta aplicación incluye una función de Azure que se puede invocar directamente a través de un endpoint HTTP. A continuación se detallan los pasos para ejecutar la función y una breve explicación de los parámetros involucrados.

## URL de la Función
La función de Azure puede ser ejecutada utilizando el siguiente enlace: https://telegestion-iot.azurewebsites.net/api/HttpTrigger1?code=BoKIoZYJ4_tSS7yL2c2L4tJLFMItFZzYFQMvIv6frRJpAzFuv23Gtg==&freq=5000

## Descripción de los Parámetros

- `code`: Este parámetro es un token de autenticación que permite la ejecución segura de la función. Asegúrate de mantenerlo confidencial y no compartirlo públicamente.
- `freq`: Este parámetro define la frecuencia (en milisegundos) con la que deseas ejecutar la función. En el ejemplo proporcionado, la frecuencia está establecida en 5000 milisegundos (5 segundos).

## Instrucciones de Ejecución

1. **Abrir el Navegador**: Copia y pega el enlace de la función en la barra de direcciones de tu navegador web.
   
2. **Modificar Parámetros (Opcional)**: Si deseas cambiar la frecuencia de ejecución, modifica el valor del parámetro `freq` en la URL. Por ejemplo, para ejecutar la función cada 10 segundos, ajusta `freq=10000`.

3. **Acceder al Enlace**: Presiona "Enter" para acceder al enlace y ejecutar la función. 

4. **Ver Resultados**: La respuesta de la función debería aparecer en tu navegador, mostrando la información o resultados generados por la función.
