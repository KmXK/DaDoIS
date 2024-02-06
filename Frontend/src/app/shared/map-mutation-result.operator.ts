import { MutationResult } from 'apollo-angular';
import { catchError, map, OperatorFunction, throwError } from 'rxjs';
import { Optional } from './types';

type ErrorExtension = {
    Message: string;
    PropertyName: string;
};

function toLowerCase(str: string): string {
    return str[0].toLowerCase() + str.slice(1);
}

function concatArrays<T>(...arrays: Optional<T[]>[]): T[] {
    const array = [] as T[];
    for (const arr of arrays) {
        if (arr) {
            array.push(...arr);
        }
    }
    return array;
}

export function mapMutationResult<TResult, TMappedResult>(
    mapResultFunc: (result: Optional<TResult>) => TMappedResult
): OperatorFunction<MutationResult<TResult>, TMappedResult> {
    return result =>
        result.pipe(
            catchError(error => {
                console.log(JSON.stringify(error));
                const extensions = concatArrays<any>(
                    error?.graphQLErrors,
                    error?.networkError.error.errors
                )
                    ?.filter(
                        (x: { message: string }) =>
                            x.message === 'Validation error'
                    )
                    ?.flatMap((x: { extensions: any }) =>
                        Object.values(x.extensions)
                    );

                console.log(extensions);

                if (extensions) {
                    return throwError(() =>
                        (<ErrorExtension[]>Object.values(extensions)).map(
                            ext => ({
                                propertyName: toLowerCase(ext.PropertyName),
                                errorMessage: ext.Message
                            })
                        )
                    );
                }

                return throwError(() => error);
            }),
            map(result => mapResultFunc(result.data))
        );
}
