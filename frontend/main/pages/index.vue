<template>
  <div>
    <div class="content flex max-w-7xl" style="margin: 0 auto">
      <div class="flex-wrap">
        <div class="disp-item flex row zdf">
          <div class="hero-image pl-5 pr-5 flex" style="">
            <img class="" src="~assets/img/image1.jpg" />
          </div>
          <div class="inner p-10 max-w-xl">
            <h1 class="title">Brand</h1>
            <div class="wpb_wrapper">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
              <p>
                Ut enim ad minim veniam, quis nostrud exercitation ullamco
                laboris nisi ut aliquip ex ea commodo consequat.
              </p>
              <p>Open 7 days a week, 6am to 7pm (kitchen: 6am to 6pm).</p>
              <a href="/Brand-Menu.pdf">
                <button
                  type="button"
                  class="
                    w-full
                    bg-blue-500
                    px-4
                    py-3
                    rounded
                    text-gray-200
                    font-semibold
                    hover:bg-blue-600
                    transition
                    duration-200
                    each-in-out
                  "
                >
                  View our menu
                </button>
              </a>
            </div>
          </div>
        </div>
        <div class="disp-item">
          <div class="grid grid-cols-3 gap-1 max-w-max mx-auto pl-5 pr-5">
            <img src="~assets/img/image2.jpg" />
            <img src="~assets/img/image2.jpg" />
            <img src="~assets/img/image2.jpg" />
            <img src="~assets/img/image2.jpg" />
            <img src="~assets/img/image2.jpg" />
            <img src="~assets/img/image2.jpg" />
          </div>
        </div>
        <div class="map mb-3">
          <iframe
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7438.016652445378!2d151.22097032494497!3d-33.85720257327587!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6b12ae665e892fdd%3A0x3133f8d75a1ac251!2sSydney%20Opera%20House!5e0!3m2!1sen!2sau!4v1635144119457!5m2!1sen!2sau"
            width="100%"
            height="450"
            frameborder="0"
            style="border: 0"
            allowfullscreen
          ></iframe>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
</script>

<style lang="scss" scoped>
.disp-item {
  padding: 3rem 0 3rem 0;
}

.wpb_wrapper p {
  margin-bottom: 15px;
}

.wwbg {
  height: calc(100vh - 377px);
  min-height: 350px;
  background-image: url('~assets/img/menu_hero.jpg');
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}

.header {
  color: white;
  font-size: 100px;
  font-family: 'Gilroy';
  font-weight: bolder;
  font-variant-caps: petite-caps;
}

.headerBar {
  background-color: #020202d1;
  color: white;
  text-align: left;
  display: flex;

  svg {
    width: 18px;
    vertical-align: middle;
  }

  p {
    margin: 10px 0 10px;
    display: flex;
  }

  a {
    color: #48a4f3;
    padding-left: 5px;
  }
}

.hero-image {
  align-items: center;
  max-height: 440px;
  max-width: 550px;
}

@media only screen and (max-width: 600px),
  only screen and (max-device-width: 600px) {
  .hero-image {
    order: 1;
  }
  .zdf {
    flex-wrap: wrap;
  }
}

@media only screen and (min-width: 1200px),
  only screen and (min-device-width: 1200px) {
}
</style>
