# Configuring the app

## HTTPs and/or custom domain

### NGINX

The following instructions apply if you want to enable HTTPs and/or change the domain to something other than the default (DOMAIN.COM).

> SSL certificates must be placed in the ``./proxy/certs`` folder.

With NGINX, if HTTPS is desired, the ``listen`` config options for each server in the config at ``./proxy/nginx/sites-enabled/default`` must be changed to

```
listen 443 ssl http2;
listen [::]:443 ssl http2;
```

Additionally, the ssl_certificate and ssl_certificate_key options for each server much be uncommented and modified to point to the SSL certificate locations.

```
ssl_certificate /certs/domain.com/fullchain.pem;
ssl_certificate_key /certs/domain.com/privkey.pem;
```

#### Custom domain

The ``server_name`` option must be modified for each server if a custom domain is used.

### Webpack

Modify the URLs at the following locations to either use HTTPs or the chosen domain.

| Service | Location |
| - | -  |
| [webpack](./frontend/scheduler/config/webpack.config.js) | ./frontend/scheduler/config/webpack.config.js |
| [onboarding actions](./frontend/hr/src/store/modules/onboarding/actions.js) | ./frontend/hr/src/store/modules/onboarding/actions.js |
| [onboarding app](./frontend/hr/src/main.js) | ./frontend/hr/src/main.js |

## Other

Settings for emails, and company name can be altered in the .ENV.
