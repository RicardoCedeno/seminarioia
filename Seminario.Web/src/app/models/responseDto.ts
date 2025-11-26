export interface Response<T extends object>{
  data: T;
  isSuccessful: boolean;
  errors: string[]
}
