<script setup>
import { RouterLink } from "vue-router";
import { storeToRefs } from "pinia";
import { useImportMetaDataStore } from "../stores/ImportMetaData";

import VueDatePicker from "@vuepic/vue-datepicker";
import "@vuepic/vue-datepicker/dist/main.css";

const { importMetaDataList, loading, error, beginDate, endDate } = storeToRefs(
  useImportMetaDataStore()
);
const { fetchImportMetaDataList } = useImportMetaDataStore();

fetchImportMetaDataList();
</script>

<template>
  <main>
    <VueDatePicker v-model="beginDate"></VueDatePicker>
    <VueDatePicker v-model="endDate"></VueDatePicker>
    <p v-if="loading">Loading importMetaDataList...</p>
    <p v-if="error">{{ error.message }}</p>
    <table class="table table-striped">
      <tbody>
        <template
          v-for="importMetaData in importMetaDataList"
          :key="importMetaData.fileName"
        >
          <tr>
            <td>{{ importMetaData.useCase }}</td>
            <td>{{ importMetaData.fileName }}</td>
            <td>
              <router-link
                class="btn btn-primary"
                :to="{
                  name: 'inhalte',
                  params: {
                    useCase: `${importMetaData.useCase}`,
                    ricisInstance: `${importMetaData.ricisInstance}`,
                    betrachtungstag: `${importMetaData.betrachtungstag}`,
                  },
                }"
                >Zeige Daten</router-link
              >
            </td>
          </tr>
        </template>
      </tbody>
    </table>
  </main>
</template>
