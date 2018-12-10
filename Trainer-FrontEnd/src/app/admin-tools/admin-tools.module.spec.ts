import { AdminToolsModule } from './admin-tools.module';

describe('AdminToolsModule', () => {
  let adminToolsModule: AdminToolsModule;

  beforeEach(() => {
    adminToolsModule = new AdminToolsModule();
  });

  it('should create an instance', () => {
    expect(adminToolsModule).toBeTruthy();
  });
});
