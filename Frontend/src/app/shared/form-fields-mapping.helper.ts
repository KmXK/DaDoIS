// import { AbstractControl, Form, FormControl, FormGroup } from '@angular/forms';
//
// export type PropertyAccessor<TModel, TProperty> = (model: TModel) => TProperty;
//
// export interface FormFieldsMapping<
//     TModel,
//     TForm extends FormGroup,
//     TValue = unknown
// > {
//     modelPropertyName: keyof TModel;
//
//     form: {
//         propertyName: keyof TForm['controls'];
//         fromModel: (model: TModel) => void;
//     };
// }
//
// type FormControls<TForm extends FormGroup> = keyof Extract<
//     TForm,
//     'controls'
// >['controls'];
//
// type CommonProperties<T, U> = {
//     [K in Extract<keyof T, keyof U>]: T[K];
// };
//
// export function makeMappingByName<TModel, TForm extends FormGroup>(
//     name: Extract<keyof TForm['controls'], keyof TModel>
// ): FormFieldsMapping<TModel, TForm> {
//     return {
//         model: (model: TModel) => model[name],
//         form: (form: TForm) => form.controls[name as string]
//     };
// }
//
// export function makeMapping<TModel, TForm extends FormGroup, TValue>(
//     model: PropertyAccessor<TModel, TValue>,
//     form:
//         | PropertyAccessor<TForm, FormControl<TValue>>
//         | {
//               accessor: PropertyAccessor<TForm, FormControl<TValue>>;
//           }
// ): FormFieldsMapping<TModel, TForm, TValue> {
//     return { model, form };
// }
//
// export function makeMappings<TModel, TForm extends FormGroup>(
//     mappings: FormFieldsMapping<TModel, TForm>[]
// ): FormFieldsMapping<TModel, TForm>[] {
//     return mappings;
// }
//
// export function mapAllCommonProperties<TModel, TForm extends FormGroup>(clie);
