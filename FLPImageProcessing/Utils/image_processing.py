import cv2
import numpy as np
import sys
import os

if len(sys.argv) < 2:
    print("Erro: Caminho da imagem nao fornecido.")
    sys.exit(1)

image_path = sys.argv[1]
img = cv2.imread(image_path)

if img is None:
    print(f"Erro: Nao foi possivel carregar a imagem do caminho '{image_path}'.")
    sys.exit(1)

output_dir = os.path.join(os.path.dirname(os.path.abspath(__file__)), 'Images')

if not os.path.exists(output_dir):
    os.makedirs(output_dir)

def edge_mask(img, line_size, blur_value):
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    gray_blur = cv2.medianBlur(gray, blur_value)
    edges = cv2.adaptiveThreshold(gray_blur, 255, cv2.ADAPTIVE_THRESH_MEAN_C, cv2.THRESH_BINARY, line_size, blur_value)
    return edges

line_size = 7
blur_value = 5
edges = edge_mask(img, line_size, blur_value)

edge_image_path = os.path.join(output_dir, 'contornos.png')
cv2.imwrite(edge_image_path, edges)

def color_quantization(img, k):
    data = np.float32(img).reshape((-1, 3))

    criteria = (cv2.TERM_CRITERIA_EPS + cv2.TERM_CRITERIA_MAX_ITER, 20, 0.001)

    ret, label, center = cv2.kmeans(data, k, None, criteria, 10, cv2.KMEANS_RANDOM_CENTERS)
    center = np.uint8(center)
    result = center[label.flatten()]
    result = result.reshape(img.shape)
    return result

total_color = 6
img = color_quantization(img, total_color)

quantized_image_path = os.path.join(output_dir, 'imagem_final_colorida.png')
cv2.imwrite(quantized_image_path, img)

gray_image = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

final_image_path = os.path.join(output_dir, 'imagem_final_pb.png')
cv2.imwrite(final_image_path, gray_image)

print(f"As imagens foram salvas com sucesso em: {output_dir}")
