import { YourToolsRoutingModule } from './your-tools-routing.module';

describe('YourToolsRoutingModule', () => {
  let yourToolsRoutingModule: YourToolsRoutingModule;

  beforeEach(() => {
    yourToolsRoutingModule = new YourToolsRoutingModule();
  });

  it('should create an instance', () => {
    expect(yourToolsRoutingModule).toBeTruthy();
  });
});
