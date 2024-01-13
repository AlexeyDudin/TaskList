export type StatusDto = {
  id: number;
  name: string;
};

export function isStatusDto(obj: StatusDto): obj is StatusDto {
  return "id" in obj && "name" in obj;
}

export function isStatusDtoArray(obj: StatusDto[]): obj is StatusDto[] {
  obj.forEach((element) => {
    if (!isStatusDto(element)) return false;
  });
  return true;
}
