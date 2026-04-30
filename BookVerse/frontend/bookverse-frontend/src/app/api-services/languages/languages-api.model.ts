export interface ListLanguagesQueryDto {
  id: number;
  name: string;
}

export interface ListLanguagesRequest {
  language?: string | null;
}
