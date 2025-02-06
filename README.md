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

## Accessing the Container and Running Migrations

To get a bash shell inside the container and run migrations, follow these steps:

1. List the running containers to find the container ID or name:

```sh
docker ps
```

2. Access the container's bash shell:

```sh
docker exec -it <container_id_or_name> /bin/bash
```

3. Run the migrations inside the container:

```sh
dotnet ef database update
```

Replace `<container_id_or_name>` with the actual container ID or name from the `docker ps` output.
