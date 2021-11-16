using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MessagePipe;

namespace MessagePipeSamples.Interprocess
{
    public class InterprocessView : MonoBehaviour
    {
        [SerializeField] private Button _sendMessageButton;
        // [SerializeField] private Text _messageText;
        [SerializeField] private TMP_Text _messageText;

        public ISubscriber<string> OnSendMessage { get; private set; }
        private IDisposablePublisher<string> _sendMessagePublisher;

        private int _messageCount;

        [VContainer.Inject]
        public void Construct(EventFactory eventFactory)
        {
            (_sendMessagePublisher, OnSendMessage) = eventFactory.CreateEvent<string>();
        }

        private void Awake()
        {
            _sendMessageButton.onClick.AddListener(() => 
            {
                _sendMessagePublisher.Publish($"Message count: {_messageCount++}");
            });
        }

        private void OnDestroy()
        {
            _sendMessagePublisher.Dispose();
            _sendMessageButton.onClick.RemoveAllListeners();
        }

        public void SetMessageText(string value)
        {
            _messageText.text = value;
        }
    }
}
