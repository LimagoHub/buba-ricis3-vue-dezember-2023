import { defineStore } from 'pinia';
import  axios  from 'axios';

export const useImportMetaDataStore = defineStore({
    id: 'importMetaData',
    state: () => ( {
        importMetaDataList: [],
        importMetaData: null,
        beginDate: new Date(),        
        endDate: new Date(),        
        loading: false,
        error: null
    }),
    getters: {
        //getPostsPerAuthor: (state) => {
        //    return (authorId) => state.posts.filter((post) => post.userId === authorId)
        //}
    },
    actions: {
        async fetchImportMetaDataList() {
            this.importMetaDataList = [];
            this.loading = true;
            try {
                const res = await axios.get("/api/ImportMetaData", { params: {'beginDate': this.beginDate, 'endDate': this.endDate}});
                this.importMetaDataList = res.data;
            } catch (error) {
                this.error = error;
            } finally {
                this.loading = false;
            }
        }
    }
})