<template>
  <div class="footer">
    <div class="lg:container mx-auto" style="max-width: 1170px">
      <div class="row">
        <div class="flex flex-wrap info">
          <div class="flex-1 col-md-4">
            <h4>About us</h4>
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
              eiusmod tempor incididunt ut labore et dolore magna aliqua.
            </p>
          </div>
          <div class="flex-1 col-md-4">
            <div class="contact">
              <h4>Contact</h4>
              <ul>
                <li>
                  <i class="fa fa-map-marker-alt"></i>
                  <p>1 Main Street, City State 0000</p>
                </li>
                <li>
                  <i class="fa fa-phone"></i>
                  <p>+61 (07) 0000 0000</p>
                </li>
                <li>
                  <i class="fas fa-envelope"></i>
                  <p>admin@domain.com</p>
                </li>
              </ul>
            </div>
          </div>
          <div class="flex-1 col-md-4">
            <h4>Opening hours</h4>
            <ul>
              <li>
                <h5>Kitchen hours</h5>
                <p>06:00 AM - 06:00 PM</p>
              </li>
              <li>
                <h5>Main hours</h5>
                <p>06:00 AM - 07:00 PM</p>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div class="row info">
        <div class="col-md-12">
          <div class="last">
            <div class="copyright">
              <i style="position: inherit" class="far fa-copyright"></i>
              <p>2021 Brand.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.footer {
  background-color: #151515;
  color: white;
  padding: 90px 0 90px 0;
  text-align: left;

  p {
    margin-bottom: 10px;
  }

  .info {
    padding-left: 15px;
    padding-right: 15px;

    .contact li {
      padding-left: 25px;
      position: relative;
    }

    ul {
      list-style-type: none;
    }

    p {
      display: inline-block;
    }

    i {
      color: #777;
      position: absolute;
      left: 0;
      top: 0.2em;
    }

    h4 {
      color: #f5a637;
      margin-bottom: 20px;
      font-size: 18px;
      font-weight: 600;
    }
  }

  .last {
    color: grey;
    margin-top: 20px;

    p {
      display: inline-block;
    }
  }

  @media only screen and (max-width: 600px),
    only screen and (max-device-width: 600px) {
    .info {
      div {
        min-width: 100%;
      }
    }
  }
}
</style>