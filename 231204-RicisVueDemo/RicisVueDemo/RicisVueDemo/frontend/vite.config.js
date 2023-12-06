import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
    build: {

        outDir: '../wwwroot',

    },
    server: {
        proxy: {

            '/api': {
                target: 'https://localhost:7181',
                changeOrigin: true,
                secure: false,
                //ws: true,
                //rewrite: (path) => path.replace(/^\/api/, ''),
            },
        },
    },
    plugins: [
        vue(),
    ],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    }
})

