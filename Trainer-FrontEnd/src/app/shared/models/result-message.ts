export class ResultMessage<T>{
    data: T;
    status: Number;
    errorCode: Number;
    validationMessages: string[]
}