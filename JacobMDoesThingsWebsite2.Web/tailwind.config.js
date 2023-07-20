/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml}"
    ],

    theme: {
        boxShadow: {
            'sm': '0 1px 2px 0 rgb(0 0 0 / 0.05)',
            'DEFAULT': '0 1px 3px 0 rgb(0 0 0 / 0.1), 0 1px 2px -1px rgb(0 0 0 / 0.1)',
            'md': '0 4px 6px -1px rgb(0 0 0 / 0.1), 0 2px 4px -2px rgb(0 0 0 / 0.1)',
            'lg': '0 10px 15px -3px rgb(0 0 0 / 0.1), 0 4px 6px -4px rgb(0 0 0 / 0.1)',
            'xl': '0 20px 25px -5px rgb(0 0 0 / 0.1), 0 8px 10px -6px rgb(0 0 0 / 0.1)',
            '2xl': '0 25px 50px -12px rgb(0 0 0 / 0.25)',
            'inner': 'inset 0 2px 4px 0 rgb(0 0 0 / 0.05)',
            'none': 'none',
        },
        colors: {
            'brand': '#e87121',
            'codebg': '#011627'
        },
        extend: {},
        purge: {
            content: [

            ],
            options: {
                safelist: {
                    standard: [
                        'text-2xl',
                        'text-3xl',
                        'text-4xl',
                        'text-5xl',
                        'text-6xl',
                        'sm:text-2xl',
                        'sm:text-3xl',
                        'sm:text-4xl',
                        'sm:text-5xl',
                        'sm:text-6xl',
                        'md:text-2xl',
                        'md:text-3xl',
                        'md:text-4xl',
                        'md:text-5xl',
                        'md:text-6xl',
                        'lg:text-2xl',
                        'lg:text-3xl',
                        'lg:text-4xl',
                        'lg:text-5xl',
                        'lg:text-6xl',
                    ],
                },
            },
        },
    },
    plugins: [
    ],
}

