#FROM microsoft/aspnet:1.0.0-beta8
FROM microsoft/aspnet:1.0.0-beta8-coreclr

COPY project.json /app/
WORKDIR /app
RUN ["dnu", "restore"]
COPY . /app

EXPOSE 8080
ENTRYPOINT ["dnx", "-p", "project.json", "kestrel"]

