# Test App

A basic WebApi application for testing technologies/design patterns in `.NET`.

## Steps for running in Docker:

### Set up user secrets

- Open a CLI in the `TestApp.Webapp` directory
  - Run `$ dotnet dev-certs https -ep "${HOME}"/.aspnet/https/webapp.pfx -p CERT_PASSWORD`
    - (For `CERT_PASSWORD`, use a password of your choice [you must provide a password; an empty pw will not work when you try to run it]).
  - Run `$ dotnet user-secrets init` to create a `<UserSecretsId>` key in `TestApp.Webapp.csproj`. (Note: This has already been done for this app.)
  - Run `$ dotnet user-secrets set "Kestrel:Certificates:Default:Password" "<CERT_PASSWORD>"`
    - Using the password you used above for `<CERT_PASSWORD>`

### Run

- Go back to the top-level directory
  - Run `$ docker-compose build` to build the Docker image.
  - Run `$ docker-compose up` to run the application
- The app will run on <http://localhost:8000> and <https://localhost:8001>
