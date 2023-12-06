<script setup>
    import { useRoute } from 'vue-router';
    import InhalteComponent from '../components/InhalteComponent.vue';
    const route = useRoute();
</script>

<template>
  <main>
    <InhalteComponent :useCase="route.params.useCase" :ricisInstance="route.params.ricisInstance" :betrachtungstag="route.params.betrachtungstag"/>
  </main>
</template>
