# BackHackthon 🌐

🎉 **Bienvenido al proyecto BackHackthon!** 🎉

Este proyecto es una **API REST** construida con **ASP.NET Core**, **Entity Framework Core** y sigue principios de **Clean Architecture**.

---

## 📁 Estructura del Proyecto

```bash
BackHackthon/
├─ ApiHabita/         # 🏗️ Capa Web API (Controladores, Servicios, Middlewares)
│  ├─ Controllers/    # 🎛️ Controladores REST
│  ├─ Services/       # ⚙️ Lógica de negocio (IUserService, UserService)
│  ├─ Extensions/     # ➕ Extensiones de configuración
│  ├─ Helpers/        # 🛠️ Middlewares y utilidades
│  ├─ Profiles/       # 🔄 Mappeo AutoMapper
│  ├─ Program.cs      # 🚀 App bootstrap y configuración
│  └─ appsettings.json# ⚙️ Configuración de settings
├─ Application/       # 📝 Capa de aplicación (DTOs, Interfaces, Use Cases)
│  ├─ DTOs/           # 🗂️ Data Transfer Objects
│  └─ Interfaces/     # 🧩 Repositorios e interfaces
├─ Domain/            # 💡 Capa de dominio (Entidades y lógica de negocio básica)
│  └─ Entities/       # 🏷️ Modelos de dominio
├─ Infrastructure/    # 🏗️ Infraestructura (DbContext, Repositorios, UnitOfWork)
│  ├─ Data/           # 📦 ApiHabitaDbContext y migraciones
│  ├─ Repositories/   # 📚 Repositorios EF Core
│  └─ UnitOfWork/     # 🔄 Patrón Unidad de Trabajo
├─ BackHackthon.sln    # 🔧 Solución .NET
└─ README.md           # 📖 Documentación del proyecto
```

## 🧩 ¿Por qué Arquitectura Hexagonal?

La Arquitectura Hexagonal o de Puertos y Adaptadores nos ayuda a:
- 🔌 Desacoplar el núcleo de negocio de detalles externos (UI, DB, APIs).
- ✅ Facilitar pruebas unitarias simulando adaptadores.
- ⚙️ Mantener flexibilidad para cambiar frameworks y tecnologías.
- 📈 Escalar y mantener el proyecto con mayor facilidad.
- 🛡️ Mejorar la mantenibilidad y claridad al separar responsabilidades.

---

## ⚙️ Configuración y Ejecución

1. Clonar el repositorio:
   ```powershell
   git clone https://github.com/Equipo-TNT/Habita-Back.git
   ```
2. Moverse al directorio de la API:
   ```powershell
   cd ApiHabita
   ```
3. Aplicar migraciones a la base de datos:
   ```powershell
   dotnet ef database update
   ```
4. Ejecutar la API:
   ```powershell
   dotnet run --project ApiHabita/ApiHabita.csproj
   ```

---

## 🛠️ Uso de Swagger UI

El proyecto incluye **Swagger** para explorar y probar los endpoints de forma interactiva:

1. Inicia la API (ver sección anterior).
2. Abre tu navegador en:
   ```
   http://localhost:{puerto}/swagger
   ```
3. Verás una interfaz interactiva con:
   - **Documentación** de cada endpoint
   - **Parámetros** de entrada
   - **Botones** para probar llamadas (Try it out)

> ⚡ *Tip*: Reemplaza `{puerto}` por el puerto que muestra la consola al iniciar la API.

---

## 🚀 Buenas Prácticas

- Autenticación con **JWT**: usa `/api/auth/login` para obtener tu token.
- Paginación: `?pageNumber=1&pageSize=10` en endpoints que lo soportan.
- Manejo de errores consistente: código y mensajes claros.

---

## 📄 Licencia

Este proyecto está licenciado bajo **MIT**. ¡Usa con responsabilidad! 👍
