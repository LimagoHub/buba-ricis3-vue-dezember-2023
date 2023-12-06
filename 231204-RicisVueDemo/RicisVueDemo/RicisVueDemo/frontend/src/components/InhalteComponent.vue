<script setup>
import SuccessToastComponent from "./SuccessToastComponent.vue";
import { RouterLink } from "vue-router";
import { storeToRefs } from "pinia";
import { useInhaltStore } from "../stores/Inhalt";
import { ref, onMounted } from "vue";

const { inhalte, inhalteAlt, loading, error, sending } = storeToRefs(useInhaltStore());
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

    
      
   
};

function say( event) {
  event.preventDefault();
  if( event.target.tagName === "INPUT") {
    let oldvalue = event.target.getAttribute("data-oldvalue");
    event.target.value = oldvalue;  
  }
  
}
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
      
      id="myTable"
    >
      <tbody  @contextmenu="say($event)">
        <template v-for="(inhalt,index) in inhalte" :key="inhalt.id">
          <tr>
            <td>{{ index }}</td>
            <td>
              <input
                :data-oldvalue="inhalteAlt[index].referenceRate"
                v-model="inhalt.referenceRate"
                type="text"
              />
            </td>
            <td><input :data-oldvalue="inhalteAlt[index].date" v-model="inhalt.date" type="text" /></td>
            <td><input :data-oldvalue="inhalteAlt[index].value" v-model="inhalt.value" type="text" /></td>
          </tr>
        </template>
      </tbody>
    </table>
  </main>
</template>

<style scoped></style>
