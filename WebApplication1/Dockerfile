FROM ubuntu:xenial

RUN apt-get update
RUN apt-get -y install apt-transport-https
RUN sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
RUN apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
RUN apt-get update

RUN apt-get install -y dotnet-dev-1.0.0-preview2-003121

ADD . /app
WORKDIR /app
RUN ["dotnet", "restore"]
EXPOSE 8080
WORKDIR /app/src/WebApplication1/
ENTRYPOINT ["dotnet", "run", "-p", "project.json"]