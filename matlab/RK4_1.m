clear all;
format long;
a = -1.1;
b = -0.1;
n = 10;
h = (b-a)/n;
x = zeros(1, n+1);
y = zeros(1, n+1);
y0 = zeros(1, n+1);
d = zeros(1, n+1);
i_i = zeros(n+1, 1);

%Построение сетки
k = a;
i_i(1, 1) = 0;
for p = 1:(n+1)
    x(1, p) = k;
    y(1, p) = nthroot(4*k, 3);
    k = k+h;
end

%Конечно-разностный аналог и сходимость
k = a;
y0(1, 1) = nthroot(4*k, 3);
for p = 1:n
    f1 = y0(1, p)/((y0(1, p))^3 - k);
    f2 = (y0(1, p)+h/2*f1)/((y0(1, p)+h/2*f1)^3-(k+h/2));
    f3 = (y0(1, p)+h/2*f2)/((y0(1, p)+h/2*f2)^3-(k+h/2));
    f4 = (y0(1, p)+h*f3)/((y0(1, p)+h*f3)^3-(k+h));
    y0(1, p+1) = y0(1, p)+h/6*(f1+2*f2+2*f3+f4);
    d(1, p) = abs(y(1, p) - y0(1, p));
    k = k + h;
    i_i(p+1, 1) = i_i(p, 1) + 1;
end
d(1, n+1) = abs(y(1, p+1) - y0(1, p+1));

%Наибольшее значение сходимости
dm = max(d);

%Построение графиков
X = a:1/1000:b;
Y = nthroot(4.*X, 3);

figure
subplot(1,2,1);
plot(X, Y, "-", x, y0, "-.");
grid on
title('График функции y = sqrt((4*x), 3)')
xlabel('X')
ylabel('Y')
legend("Аналитическое решение", "Численное решение");

subplot(1,2,2);
plot(x, d);
grid on
str = {'h = ' + string(h),'Δ^m = ' + string(dm)};
text(-0.6, 0.0000000015, str);
title('Графики сходимости функции y = sqrt((4*x), 3)')
xlabel('X')
ylabel("Y")

xi = x';
yi = y0';
yi_0= y';
DeltaY = d';

T = table(i_i, xi, yi, yi_0, DeltaY);
writetable(T,'table_RK4.xlsx');
