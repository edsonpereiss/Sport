# Iniciar do Zero

# // comments command docker compose
# command: [--auth]

# docker stop $(docker ps -aq)
# docker system prune --all --force --volumes
# docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
# docker exec -it sportDb bash

# mongo

# use admin
# db.createUser(
#   {
#     user: "root",
#     pwd: "Mongo2021", // or cleartext password
#     roles: [ { role: "userAdminAnyDatabase", db: "admin" }, "readWriteAnyDatabase" ]
#   }
# )


# use sportDb

# db.createUser(
#   {
#     user: "football",
#     pwd:  "Mongo2021",   // or cleartext password
#     roles: [ { role: "readWrite", db: "sportDb" } ]
#   }
# )

# db.adminCommand( { shutdown: 1 } )

# docker stop sportDb

# // Add command docker compose
# command: [--auth]

# docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

# mongodb://soccer:Mongo2021@localhost:27017

