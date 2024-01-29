FROM node:20.11.0

WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH

COPY package.json /app/package.json
RUN npm install
RUN npm install -g @angular/cli@17
RUN ng analytics off -g

COPY . /app

CMD npm start