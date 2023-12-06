import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"

// Fuer Webpack
import * as bootstrap from 'bootstrap';
window.bootstrap = bootstrap;

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'

const app = createApp(App)
app.component('VueDatePicker', VueDatePicker);

app.use(createPinia())
app.use(router)

app.mount('#app')
