<script setup>
import SuccessToastComponent from "./SuccessToastComponent.vue";
import { RouterLink } from "vue-router";
import { storeToRefs } from "pinia";
import { useInhaltStore } from "../stores/Inhalt";
import { ref, onMounted } from "vue";

const { inhalte, loading, error, sending } = storeToRefs(useInhaltStore());
const { fetchInhalte, sendInhalte } = useInhaltStore();

const props = defineProps(["useCase", "ricisInstance", "betrachtungstag"]);
fetchInhalte(props.useCase, props.ricisInstance, props.betrachtungstag);
var saveMethod = (useCase, ricisInstance, betrachtungstag) => {
  sendInhalte(useCase, ricisInstance, betrachtungstag)
    .then(() => {
      let element = document.getElementById("successToast");
      let myToastHandler = new bootstrap.Toast(element, {
        animation: true,
        delay: 5000,
      });
      myToastHandler.show(element);
    })
    .catch(() => {
      alert("Fehler");
    });

  var select = (event) => {
    alert("hallo");
    myTarget = event.currentTarget;
    alert(myTarget.element); // returns 'foo'
  };
};
</script>

<template>
  <main>
    <SuccessToastComponent msg="Daten erfolgreich" />
    <p v-if="loading">Loading inhalte...</p>
    <p v-if="error">{{ error.message }}</p>

    <div class="container">
      <button
        type="button"
        class="btn btn-primary"
        data-bs-toggle="modal"
        data-bs-target="#myModal"
      >
        Daten speichern
      </button>
    </div>
    <p>{{ useCase }} {{ ricisInstance }} {{ betrachtungstag }}</p>
    <!-- The Modal -->
    <div class="modal" id="myModal" ref="myModal">
      <div class="modal-dialog">
        <div class="modal-content">
          <!-- Modal Header -->
          <div class="modal-header">
            <h4 class="modal-title">Modal Heading</h4>
            <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
          </div>
          <!-- Modal body -->
          <div class="modal-body">Modal body..</div>
          <!-- Modal footer -->
          <div class="modal-footer">
            <button
              @click="
                saveMethod(props.useCase, props.ricisInstance, props.betrachtungstag)
              "
              type="button"
              class="btn btn-primary"
              data-bs-dismiss="modal"
            >
              Send
            </button>
            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">
              Close
            </button>
          </div>
        </div>
      </div>
    </div>

    <table
      v-if="inhalte"
      class="table table-striped"
      v-on:click="alert('Test')"
      id="myTable"
    >
      <tbody>
        <template v-for="inhalt in inhalte" :key="inhalt.id">
          <tr>
            <td>
              <input
                v-on:contextmenu="alert('Test')"
                v-model="inhalt.referenceRate"
                type="text"
              />
            </td>
            <td><input v-model="inhalt.date" type="text" /></td>
            <td><input v-model="inhalt.value" type="text" /></td>
          </tr>
        </template>
      </tbody>
    </table>
  </main>
</template>

<style scoped></style>
