FROM node:12.18.3-alpine as main
WORKDIR /app

COPY main /app
RUN npm install
RUN npm run build
RUN npm run generate



FROM node:12.18.3-alpine as scheduler
WORKDIR /app

COPY scheduler /app
RUN npm install
RUN npm run build



FROM node:12.18.3-alpine as hr
WORKDIR /app

COPY hr /app
RUN npm install
RUN npm run build



FROM node:12.18.3-alpine as frontend

WORKDIR /app

COPY package.json /app
RUN npm install

COPY . /app
COPY --from=main /app/dist ./dist/main
COPY --from=scheduler /app/public ./dist/scheduler
COPY --from=hr /app/dist ./dist/hr

CMD [ "/usr/local/bin/node", "./server.js" ]

EXPOSE 4456


