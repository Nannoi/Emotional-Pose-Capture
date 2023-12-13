import cv2
from cvzone.PoseModule import PoseDetector
import socket

width,height=640,720
# Initialize VideoCapture
cap = cv2.VideoCapture(0)  # 0 for default webcam, or provide a video file path
cap.set(3,640)
cap.set(4,720)

detector = PoseDetector()

# Communication
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

while True:
    # Read a frame from the webcam
    success, img = cap.read()
    # Flip the image horizontally (mirror effect)
    img = cv2.flip(img, 1)

    img = detector.findPose(img)
    lmList, bboxInfo = detector.findPosition(img)
    data = []  # Move the initialization outside the loop

    if lmList:  # Check if lmList is not empty
        for lm in lmList:
            # Ensure lm has at least 4 elements before accessing them
            data.extend([width-lm[0], height - lm[1], lm[2]])

        print(data)

        # Send points from body detection to Unity
        sock.sendto(str.encode(str(data)), serverAddressPort)

    cv2.imshow("image", img)
    key = cv2.waitKey(1)
