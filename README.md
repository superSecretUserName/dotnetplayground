# MyDotnetWebApp

## Running the Project with Docker Compose

To run the project using Docker Compose, follow these steps:

1. Ensure you have Docker and Docker Compose installed on your machine.
2. Navigate to the project directory:

```sh
cd path/to/your/project
```

3. Start the Docker containers:

```sh
docker-compose up -d
```

## Notes:

- The application is setup to automatically run any pending migrations and then seed the database with some entries upon launch.
- Since this is just a local project to learn some .NET, the database connection string is hardcoded into Program.cs.
