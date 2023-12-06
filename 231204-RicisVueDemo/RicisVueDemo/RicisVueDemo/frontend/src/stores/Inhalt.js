import { defineStore } from 'pinia';
import  axios  from 'axios';

export const useInhaltStore = defineStore({
    id: 'inhalt',
    state: () => ({
        inhalte: [],
        inhalteAlt: [],
        inhalt: null,
        loading: false,
        sending: false,
        error: null
    }),
    getters: {
        //getPostsPerAuthor: (state) => {
        //    return (authorId) => state.posts.filter((post) => post.userId === authorId)
        //}
    },
    actions: {
        async fetchInhalte(usecase, instance, betrachtungstag) {
            this.inhalte = [];
            this.loading = true;
            try {
                const res = await axios.get("/api/Inhalte", { params: { 'useCase': usecase, 'ricisInstance': instance, 'betrachtungstag': betrachtungstag }});
                this.inhalte = res.data;
                this.inhalteAlt = JSON.parse(JSON.stringify(this.inhalte));
            } catch (error) {
                this.error = error;
            } finally {
                this.loading = false;
            }
        },
        async sendInhalte(usecase, instance, betrachtungstag) {
            this.sending = true;
            try {
                return await axios({
                    url: '/api/Inhalte',
                    method: 'post',
                    params: { useCase: usecase, ricisInstance: instance, betrachtungstag: betrachtungstag },
                    data: this.inhalte
                })
            } catch (error) {
                this.error = error;
            } finally {
                this.sending = false;
            }
        }
    }
})