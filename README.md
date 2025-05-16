# Examen 1 de moviles BACKEND

# Índice
1. [Integrantes](#integrantes)
2. [Instalación](#instalación)
3. [Configuración](#configuración) 
4. [Uso](#uso)

## Integrantes:
    Daniel Briones Vargas - A-BrionesVargas
    Josue Porras Rojas - Josue_Porras


# Instalación
```bash
    git clone https://github.com/ExamenUnoMoviles/ExamenMoviles_backend.git
```

# Configuración

## Conexión a la base de datos
Una vez clonado el repositorio cambiar el **DefaultConnection** de **appsettings** con sus credenciales.
```bash
"DefaultConnection": "Server=localhost,1433;Database=Examen_Moviles;User Id=<NOMBRE DE USUARIO>;Password=<CONTRASEÑA>;TrustServerCertificate=True;"
```
> [!NOTE]
>Cambiar **NOMBRE DE USUARIO** con su usuario de SQLServer y **CONTRASEÑA** con su contraseña de SQLServer.

## Migraciones
Una vez configurada la conexión a la base de datos crear las migraciones con los siguientes comandos:
```bash
    dotnet ef migrations add <NOMBRE DE LA MIGRACIÓN>
    dotnet ef database update
```
> [!NOTE]
>Cambiar **NOMBRE DE LA MIGRACIÓN** por algún nombre descriptivo ejemplo: **InitExam**

## Uso
Una vez configurada la conexión a la base de datos junto con las migraciones ejecutar el proyecto con el siguiente comando.
```bash
    dotnet build
    dotnet watch run
```