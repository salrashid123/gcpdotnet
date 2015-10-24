#FROM microsoft/aspnet:1.0.0-beta8
FROM microsoft/aspnet:1.0.0-beta8-coreclr

ADD . /app
WORKDIR /app
RUN ["dnu", "restore"]

EXPOSE 8080
ENTRYPOINT ["dnx", "-p", "src/WebApplication1/project.json", "kestrel"]
