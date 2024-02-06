import type { CodegenConfig } from '@graphql-codegen/cli';

const config: CodegenConfig = {
    overwrite: true,
    schema: 'http://localhost:4200/graphql',
    documents: './src/**/*.ts',
    generates: {
        'src/graphql.ts': {
            plugins: [
                'typescript',
                'typescript-operations',
                'fragment-matcher',
                'typescript-apollo-angular'
            ]
        }
    }
};

export default config;
