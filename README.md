# EventManagement

1. Arquitectura del Proyecto

El proyecto se dividió en dos partes principales: **Backend** y **Frontend** (Interfaz de usuario). 

- **Backend**: Se desarrolló utilizando **C#** y el **.NET Framework 4.8**, implementando una **API RESTful** que maneja las operaciones CRUD sobre las entidades. Utiliza **MySQL** como base de datos.
- **Frontend**: Se creó una interfaz de usuario utilizando **HTML**, **CSS** (con **Bootstrap** para el diseño responsivo), **JavaScript** y **fetch API** para consumir el servicio web. El frontend está diseñado para interactuar con el backend y manejar las acciones del usuario, como inicio de sesión, visualización de eventos, creación y edición.

### 2. **Backend: API RESTful con .NET Framework 4.8**

#### a. **Configuración del Proyecto en Visual Studio**:
- Se creó un proyecto **ASP.NET Web API** en Visual Studio 2022 con **.NET Framework 4.8**.
- Se añadieron las dependencias necesarias, como **MySql.Data** para conectar con la base de datos MySQL.
  
#### b. **Modelo de Datos**:
Se definieron las siguientes clases que representan las entidades de la base de datos (relacionadas con eventos y usuarios):
  - **Usuario**: Representa a un usuario que puede interactuar con el sistema (ID, nombre, correo, rol).
  - **Rol**: Define el rol de un usuario (ID, nombre).
  - **Evento**: Representa un evento (ID, título, descripción, lugar, fecha).

Estas clases se utilizaron para mapear los datos de la base de datos y realizar operaciones CRUD.

#### c. **Conexión a MySQL**:
Se configuró la cadena de conexión en el archivo `web.config` para conectar con la base de datos MySQL.
  
#### d. **Controladores (Controllers)**:
Se crearon controladores para manejar las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) de los **Eventos** y **Usuarios**.
  - **EventoController**: Maneja las solicitudes de eventos (listado, agregar, editar, eliminar).
  - **AuthController**: Realiza la autenticación básica de usuarios utilizando correo y contraseña.

#### e. **Autenticación**:
Para la autenticación, se utilizó un enfoque básico con **autenticación por formularios**. El backend valida el usuario (correo y contraseña) y emite un token simple para manejar la sesión.

#### f. **CORS**:
Se configuró **CORS** (Cross-Origin Resource Sharing) para permitir que el frontend (en `localhost:44307`) pueda consumir la API (en `localhost:3080`). Esto se configuró a través de `WebApiConfig.cs`, habilitando CORS para permitir solicitudes de estos orígenes.

#### g. **API Restful**:
El backend expone las siguientes rutas para interactuar con los datos:
- `GET /api/Eventos`: Obtiene todos los eventos.
- `POST /api/Eventos`: Crea un nuevo evento.
- `PUT /api/Eventos/{id}`: Actualiza un evento.
- `DELETE /api/Eventos/{id}`: Elimina un evento.
- `POST /api/Login`: Autentica al usuario.

### 3. **Frontend: Interfaz de Usuario**

#### a. **Estructura HTML**:
Se crearon varias páginas HTML para interactuar con el sistema:
  - **login.html**: Formulario de inicio de sesión donde los usuarios ingresan su correo y contraseña.
  - **evento.html**: Página principal para mostrar la lista de eventos.
  - **evento_form.html**: Formulario para agregar y editar eventos.

#### b. **Interactividad con JavaScript**:
- Se utilizó **JavaScript** para consumir la API del backend a través de la función **fetch()**, cargando y enviando datos de manera asíncrona.
- **Eventos**: La página `evento.html` obtiene los eventos del backend y los muestra en una tabla. También permite editar o eliminar eventos utilizando botones.
- **Formulario de Evento**: La página `evento_form.html` permite agregar nuevos eventos o editar eventos existentes. Se utiliza un formulario con campos como **Título**, **Descripción**, **Lugar** y **Fecha**.

#### c. **Interacción con la API**:
- **Autenticación**: El frontend envía los datos del formulario de inicio de sesión al endpoint `/api/Login` para autenticar al usuario.
- **Operaciones CRUD**: Las acciones de agregar, editar o eliminar eventos se realizan con solicitudes HTTP a los endpoints correspondientes de la API.

#### d. **Diseño con Bootstrap**:
Se utilizó el framework **Bootstrap** para diseñar las páginas y asegurar que fueran responsivas. Las tablas, formularios y botones están diseñados utilizando las clases prediseñadas de Bootstrap.

### 4. **Configuración de IIS y Servidor**

#### a. **Configuración de IIS**:
- Se configuraron las aplicaciones en IIS para servir tanto el frontend (en `localhost:44307`) como el backend (en `localhost:3080`).
- El backend fue configurado para ejecutarse con **.NET Framework 4.8**, y se habilitó **CORS** para permitir la comunicación entre ambos dominios.

#### b. **Seguridad**:
Aunque no se implementó cifrado de contraseñas ni autenticación avanzada, se configuró **autenticación por formularios** básica en el archivo `web.config`, y se habilitó un nivel mínimo de control de acceso en la API para los usuarios autenticados.

### 5. **Problemas y Soluciones**

A lo largo del proyecto, surgieron algunos problemas comunes:
- **Conexión CORS**: Se solucionó configurando correctamente CORS en el backend.
- **Errores de configuración en `web.config`**: Se revisaron las configuraciones de IIS y `web.config` para asegurar que no hubiera errores en la estructura o configuraciones de autenticación.
- **Autenticación básica**: Se implementó un sistema básico de autenticación por correo y contraseña, aunque se podría mejorar con un enfoque más seguro en el futuro.
