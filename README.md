# Test App

A basic WebApi application for testing out various things.

## Steps for running in Docker:

- Open a CLI in the `/webapp` directory
  - Run `$ dotnet dev-certs https -ep ${HOME}/.aspnet/https/webapp.pfx -p $cert_password`
    - (For `$cert_password`, use a password of your
      choice [you must provide a password; an empty pw will not work when you try to run it]).
  - Run `$ dotnet user-secrets init` to create a `<UserSecretsId>` key in `webapp.csproj`. (Note: This has already been done for this app.)
- Edit the file `${HOME}/.microsoft/usersecrets/$user_secrets_id}/secrets.json` to match:
    - (For `$user_secrets_id`, use the value of `<UserSecretsId>` in `webapp.csproj`)

```json
{
  "Kestrel:Certificates:Default:Path": "/root/.aspnet/https/webapp.pfx",
  "Kestrel:Certificates:Default:Password": "$cert_password"
}
```

- Go back to the `/webapp/` directory
  - Run `$ docker-compose build` to build the Docker image.
  - Run `$ docker-compose up` to run the application
- The app will run on <http://localhost:8000> and <https://localhost:8001>
