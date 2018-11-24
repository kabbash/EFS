FROM node:8-alpine as buildContainer
WORKDIR /app
COPY ./package.json ./package-lock.json /app/
RUN npm install
COPY . /app
RUN node_modules/.bin/ng build --prod
RUN node_modules/.bin/ng run Trainer-FrontEnd:server
RUN node_modules/.bin/webpack --config webpack.server.config.js --progress --colors
# RUN node dist/server



FROM node:8-alpine
WORKDIR /app
# Copy dependency definitions
COPY --from=buildContainer /app/package.json /app
COPY --from=buildContainer /app/server.ts /app

# Get all the code needed to run the app
COPY --from=buildContainer /app/dist /app/dist
# COPY --from=buildContainer /app/static /app/static
# COPY --from=buildContainer /app/dist-server /app/dist-server

# Expose the port the app runs in
EXPOSE 80/tcp
# EXPOSE 4000

# Serve the app
CMD ["node", "dist/server"]