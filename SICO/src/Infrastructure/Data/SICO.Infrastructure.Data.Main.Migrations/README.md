# Proyecto generacion de migración de esqumea de base de datos con entity framework
A continuación se muestra los pasos a seguir para generar el esquema con .NET Core CLI tool

## 1. primero debemos habilitar la migración (omitir este paso si ya esta habilitado)
dotnet ef migrations enable

## 2. Agregamados una nueva migración (ejecutar este comando cada vez que se haga cambios a las entidades)
dotnet ef migrations add Initial

## 3. Actualizamos la base de datos
dotnet ef database update

Ejecutar los comandos anteriores en la consola de windows en el directorio del proyecto de windows 


# Para generar migrations para columnas calculadas seguir los siguientes pasos.

## 1. Agregar un migration con el siguiente formato : Add_Computed_Column_[Coolumn_Name]_Table_[Table_Name]
## 2. Dentro del metodo up del migration generado agregar la siguiente linea de codigo:
	Sql("ALTER TABLE dbo.[Table_Name] ADD [Coolumn_Name] AS (dbo.UFN_GetNextCodeSequence('MC',Id,4))");
## 3. actualizar el migrations 
     dotnet ef database update Add_Computed_Column_[Coolumn_Name]_Table_[Table_Name]

# Utilitarios para sql server:

##1. Resetear identity sql server 
DBCC CHECKIDENT ('[Trademark]', RESEED, 0);
