export interface RegistrtionData {
  email: string,
  password: string,
  name: string,
  familyName: string,
  age: number
}

export interface CreateHeroData {
  Name: string
  IsAttacker: boolean
  SuitColor: string
  StartingPower: number
}

export interface LoginData {
  email: string,
  password: string,
}

export interface RegisterResponse {
  errors: string[],
  succeeded: boolean
}

export interface PowerUpdateResponse {
  isTrainSuccess: boolean
  updatedPower: number
}

export interface DeleteHeroResponse {
  isDeleted: boolean
  reason: string
}

export interface ServerResponse {
  isSuccessed: boolean
  error: Error
  data: any
}

interface Error {
  errorCode: string
  errorMessage: string
}
