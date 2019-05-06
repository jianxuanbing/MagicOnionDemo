using Grpc.Core;
using MagicOnion.Server;
using Bing.Reflections;

namespace MagicOnionDemo.Core
{
    /// <summary>
    /// RPC服务器
    /// </summary>
    public class RpcServer
    {
        private static MagicOnionServiceDefinition _services;
        private static Server _server;

        public RpcServer()
        {
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());
            var assemblies = new AppDomainTypeFinder().GetAssemblies().ToArray();
            var service = MagicOnionEngine.BuildServerServiceDefinition(assemblies, new MagicOnionOptions(true));
            var options = new ChannelOption[]
            {
                new ChannelOption(ChannelOptions.MaxReceiveMessageLength, int.MaxValue),
                new ChannelOption(ChannelOptions.MaxSendMessageLength, int.MaxValue),
            };
            _server = new Server()
            {
                Services = { service },
                Ports = { new ServerPort("localhost", 8700, ServerCredentials.Insecure) }
            };
        }

        public void Start()
        {
            _server.Start();
        }

        public async void Close()
        {
            await _server.ShutdownAsync();
        }
    }
}
