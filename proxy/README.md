Default NGINX configuration is to use HTTP. If HTTPS is desired, please un-comment any/all commented lines in 

```/nginx/sites-enabled/default```

and remove `listen 80` from both servers that have a `listen 443 ssl http2` setting.

If a custom domain name is desired, replace all occurences of DOMAIN.COM with chosen domain.

Certificates for chosen domain should be placed in /certs.
