FROM node:8-alpine as buildContainer
WORKDIR /app
COPY ./package.json ./package-lock.json /app/
RUN npm install
COPY . /app
RUN node --max_old_space_size=20048 ./node_modules/@angular/cli/bin/ng build --prod --aot  --progress
RUN node_modules/.bin/ng run Trainer-FrontEnd:server
RUN node_modules/.bin/webpack --config webpack.server.config.js --progress --colors; exit 0



FROM node:8-alpine
WORKDIR /app
COPY --from=buildContainer /app/package.json /app
COPY --from=buildContainer /app/server.ts /app

# Get all the code needed to run the app
COPY --from=buildContainer /app/dist /app/dist


# Expose the port the app runs in
EXPOSE 80/tcp
# EXPOSE 4000

# Serve the app
CMD ["node", "dist/server"]