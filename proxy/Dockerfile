FROM nginx

# Remove sym links from nginx image
RUN rm /var/log/nginx/access.log
RUN rm /var/log/nginx/error.log

# Install logrotate
RUN apt-get update && apt-get -y install cron logrotate

#COPY ./certs /certs
COPY ./nginx /etc/nginx
COPY ./html /usr/share/nginx/html
COPY ./config/logrotate.d/nginx /etc/logrotate.d/

CMD service cron start && nginx -g 'daemon off;'