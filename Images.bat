Echo
Echo *************************** Batch Start ***************************
Echo on

docker run --rm -it -p 3000:80 -p 2525:25 rnwood/smtp4dev

docker pull datalust/seq
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest



Echo
Echo *************************** Batch End ***************************
Echo off
