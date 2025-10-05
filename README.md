The end goal of the project is to create a space where I can save recipes and then search for them later.  This will be done with a Postgres database, an API that has both a CRUD and a search tool, and eventually a front-end mobile application.
The end goal will be to host the api and database on a server, possibly run off something like a Raspberry Pi. Additionally, as a way to get better with Docker, I'm setting up the API and database to be stored in their own containers.

Goals
- API
  - Dependency injection structure (complete!)
  - Database entity framework (base is complete but may need updates as things progress)
  - Routes
    - Create (in progress)
    - Read
    - Update
    - Delete
    - Search
- Database
  - Error: The database creation code has stopped working.  Possibly due to changes with Docker.
  - Set up PG admin in Docker for easier testing (in progress)
- Front-end application
  - For now, this is treated as out of scope and will begin work later
