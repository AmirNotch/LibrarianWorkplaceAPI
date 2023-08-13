# LibrarianWorkplaceAPI

Краткое описание СТЭКА проекта (
Библиотека (Application) которая выполняет всю бизнес логику которая разбита на слои Onion Architecturё.
Паттерн CQRS + MediatR который распределяет нагрузку на БД. Используется LINQ + EntityFrameWorkCore.

AutoMapper позоляющий удобно работать с таблицами.

Domain библиотека где храняться все сущности самого приложения.

Persistence библиотека где происходит подключение к самой БД (MS SQL)

Infrastructure библиотека где происходит логика с безопасностью например хранения токенов и.т.д


Сам проект под названием LibrarianWorkplaceAPI который совершает все запросы и связывается с Библиотекой (Application). 
Паттерн CQRS + MediatR.
 
Сам проект Написан на WebAPI ASP.NET (.Net 5)
)

Команда для создание миграции = dotnet ef migrations add InitMigrations -p Persistence -s API
![Onion](https://github.com/AmirNotch/LibrarianWorkplaceAPI/assets/69799846/c593d82d-2752-4918-b8f1-35949ef5b892)
