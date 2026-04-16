export class categoryParams {
  defaultPageSize: number = 10;
  sort: string = 'dateDesc';
  pageSize: number = this.defaultPageSize;
  pageIndex: number = 1;
  search: string = '';
  isParent: boolean = false;
}
